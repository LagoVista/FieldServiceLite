using LagoVista.Core.Interfaces;
using LagoVista.Core.Managers;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Admin.Interfaces;
using LagoVista.FSLite.Models;
using LagoVista.IoT.DeviceManagement.Core;
using LagoVista.IoT.Logging.Loggers;
using System.Threading.Tasks;
using System.Linq;
using System;
using LagoVista.IoT.Deployment.Admin.Interfaces;
using LagoVista.Core;
using LagoVista.IoT.DeviceManagement.Core.Managers;
using LagoVista.IoT.Deployment.Admin.Repos;
using System.Diagnostics;
using LagoVista.IoT.DeviceManagement.Models;
using LagoVista.IoT.Deployment.Admin;
using LagoVista.UserAdmin.Interfaces.Managers;
using System.Text;
using LagoVista.IoT.Deployment.Models;
using LagoVista.IoT.DeviceManagement.Core.Models;

namespace LagoVista.FSLite.Admin.Managers
{
    public class ServiceTicketManager : ManagerBase, IServiceTicketManager, IServiceTicketCreator
    {
        private readonly IServiceTicketRepo _repo;
        private readonly IDeviceManager _deviceManager;
        private readonly IServiceTicketTemplateRepo _templateRepo;
        private readonly IServiceBoardRepo _serviceBoardRepo;
        private readonly IDeviceRepositoryManager _repoManager;
        private readonly ITicketStatusRepo _ticketStatusRepo;
        private readonly ITemplateCategoryRepo _templateCategoryRepo;
        private readonly IDeviceConfigurationManager _deviceConfigManager;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private readonly IUserManager _userManager;
        private readonly IDistributionManager _distroManager;

        public ServiceTicketManager(IServiceTicketRepo repo, IServiceBoardRepo boardRepo, IDeviceRepositoryManager repoManager, IDeviceManager deviceManager, ITemplateCategoryRepo templateCategoryRepo,
                                    IEmailSender emailSender, ISmsSender smsSender, IAppConfig appConfig, IAdminLogger logger, ITicketStatusRepo ticketStatusRepo, IServiceTicketTemplateRepo templateRepo,
                                    IDistributionManager distroManager, IUserManager userManager, IDeviceConfigurationManager deviceConfigManager, IDependencyManager depmanager, ISecurity security)
            : base(logger, appConfig, depmanager, security)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _serviceBoardRepo = boardRepo ?? throw new ArgumentNullException(nameof(boardRepo));
            _repoManager = repoManager ?? throw new ArgumentNullException(nameof(repoManager));
            _deviceManager = deviceManager ?? throw new ArgumentNullException(nameof(deviceManager));
            _templateRepo = templateRepo ?? throw new ArgumentNullException(nameof(templateRepo));
            _ticketStatusRepo = ticketStatusRepo ?? throw new ArgumentNullException(nameof(ticketStatusRepo));
            _templateCategoryRepo = templateCategoryRepo ?? throw new ArgumentNullException(nameof(templateCategoryRepo));
            _deviceConfigManager = deviceConfigManager ?? throw new ArgumentNullException(nameof(deviceConfigManager));
            _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
            _smsSender = smsSender ?? throw new ArgumentNullException(nameof(smsSender));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _distroManager = distroManager ?? throw new ArgumentNullException(nameof(distroManager));
        }

        public async Task<InvokeResult<string>> AddServiceTicketAsync(ServiceTicket serviceTicket, EntityHeader org, EntityHeader user)
        {
            ValidationCheck(serviceTicket, Actions.Create);

            await AuthorizeAsync(serviceTicket, AuthorizeResult.AuthorizeActions.Create, user, org);
            await _repo.AddServiceTicketAsync(serviceTicket);

            return InvokeResult<string>.Create(serviceTicket.TicketId);
        }

        public async Task<InvokeResult<string>> CreateServiceTicketAsync(string ticketTemplateId, string deviceRepoId, string deviceId, EntityHeader org, EntityHeader user)
        {
            if (await this._repo.HasOpenTicketOnDeviceAsync(deviceId, ticketTemplateId, org.Id))
            {
                return InvokeResult<string>.Create(String.Empty);
            }

            return await CreateServiceTicketAsync(new CreateServiceTicketRequest()
            {
                DeviceId = deviceId,
                RepoId = deviceRepoId,
                TemplateId = ticketTemplateId,
            }, org, user);
        }

        public async Task<InvokeResult<string>> CreateServiceTicketAsync(CreateServiceTicketRequest createServiceTicketRequest, EntityHeader org, EntityHeader user)
        {
            if (createServiceTicketRequest == null) throw new ArgumentNullException(nameof(createServiceTicketRequest));
            if (String.IsNullOrEmpty(createServiceTicketRequest.RepoId)) throw new ArgumentNullException(createServiceTicketRequest.RepoId);
            if (String.IsNullOrEmpty(createServiceTicketRequest.DeviceId) &&
                String.IsNullOrEmpty(createServiceTicketRequest.DeviceUniqueId)) throw new ArgumentNullException(nameof(createServiceTicketRequest.DeviceId) + " and " + nameof(createServiceTicketRequest.DeviceUniqueId));
            if (String.IsNullOrEmpty(createServiceTicketRequest.TemplateId) && 
                String.IsNullOrEmpty(createServiceTicketRequest.TemplateKey)) throw new ArgumentNullException(nameof(createServiceTicketRequest.TemplateId) + " and " + nameof(createServiceTicketRequest.TemplateKey));

            ServiceTicketTemplate template;

            if (String.IsNullOrEmpty(createServiceTicketRequest.TemplateKey))
            {
                template = await _templateRepo.GetServiceTicketTemplateAsync(createServiceTicketRequest.TemplateId);
                if (template == null)
                {
                    throw new NullReferenceException($"Could not load ticket template for {createServiceTicketRequest.TemplateId}");
                }
            }
            else
            {
                template = await _templateRepo.GetServiceTicketTemplateByKeyAsync(org.Id, createServiceTicketRequest.TemplateKey);
                if (template == null)
                {
                    throw new NullReferenceException($"Could not load ticket template for {createServiceTicketRequest.TemplateKey}");
                }
            }

            

            org ??= template.OwnerOrganization;
            user ??= template.DefaultContact ?? template.CreatedBy;

            if (org == null) throw new NullReferenceException(nameof(org));
            if (user == null) throw new NullReferenceException(nameof(user));

            var repo = await _repoManager.GetDeviceRepositoryWithSecretsAsync(createServiceTicketRequest.RepoId, org, user);
            if (repo == null) throw new InvalidOperationException($"Could not find repository for id {createServiceTicketRequest.RepoId}");
            if (org != null && template.OwnerOrganization != org) throw new InvalidOperationException("Template, org mismatch.");

            Console.WriteLine("+++1");

            Device device = null;
            if (!String.IsNullOrEmpty(createServiceTicketRequest.DeviceId))
            {
                device = await _deviceManager.GetDeviceByDeviceIdAsync(repo, createServiceTicketRequest.DeviceId, template.OwnerOrganization, user ?? template.DefaultContact);
                if (device == null)
                {
                    device = await _deviceManager.GetDeviceByIdAsync(repo, createServiceTicketRequest.DeviceId, template.OwnerOrganization, user ?? template.DefaultContact);
                    if (device == null) // still null
                    {
                        throw new ArgumentNullException($"Could not find device with device id {createServiceTicketRequest.DeviceId}.");
                    }
                }
            }
            else if (!String.IsNullOrEmpty(createServiceTicketRequest.DeviceUniqueId))
            {
                device = await _deviceManager.GetDeviceByIdAsync(repo, createServiceTicketRequest.DeviceUniqueId, template.OwnerOrganization, user ?? template.DefaultContact);
                if (device == null)
                {
                    throw new ArgumentNullException($"Could not find device with device id {createServiceTicketRequest.DeviceUniqueId}.");
                }
            }
            else
            {
                throw new ArgumentNullException("Must supply either DeviceId or DeviceUniqueId to create a service ticket.");
            }
           
            if (org != null && device.OwnerOrganization != org)
            {
                throw new InvalidOperationException("Device, org mismatch.");
            }

            Console.WriteLine("+++2");

            var stateSet = await _ticketStatusRepo.GetTicketStatusDefinitionAsync(template.StatusType.Id);
            var defaultState = stateSet.Items.Where(st => st.IsDefault).First();

            var assignedToUser = device.AssignedUser;
            if (assignedToUser == null)
            {
                assignedToUser = repo.AssignedUser;
            }

            if (assignedToUser == null)
            {
                assignedToUser = template.DefaultContact;
            }

            var currentTimeStamp = DateTime.UtcNow.ToJSONString();

            EntityHeader<ServiceBoard> boardEH = null;

            Console.WriteLine("+++3");

            var ticketId = Guid.NewGuid().ToString();

            if (!String.IsNullOrEmpty(createServiceTicketRequest.BoardId))
            {
                var board = await _serviceBoardRepo.GetServiceBoardAsync(createServiceTicketRequest.BoardId);
                boardEH = new EntityHeader<ServiceBoard>() { Id = board.Id, Text = board.Name };
                var ticketNumber = await _serviceBoardRepo.GetNextTicketNumber(createServiceTicketRequest.BoardId);
                ticketId = $"{board.BoardAbbreviation}-{ticketNumber}";

                if (assignedToUser == null && !EntityHeader.IsNullOrEmpty(board.PrimaryContact))
                {
                    assignedToUser = board.PrimaryContact;
                }
            }
            else if (!EntityHeader.IsNullOrEmpty(repo.ServiceBoard))
            {
                boardEH = new EntityHeader<ServiceBoard>() { Id = repo.ServiceBoard.Id, Text = repo.ServiceBoard.Text };

                var board = await _serviceBoardRepo.GetServiceBoardAsync(repo.ServiceBoard.Id);
                var ticketNumber = await _serviceBoardRepo.GetNextTicketNumber(repo.ServiceBoard.Id);
                ticketId = $"{board.BoardAbbreviation}-{ticketNumber}";
            }

            Console.WriteLine("+++4");

            string dueDate = null;

            if (!EntityHeader.IsNullOrEmpty(template.TimeToCompleteTimeSpan) &&
                template.TimeToCompleteTimeSpan.Value != TimeSpanIntervals.NotApplicable &&
                template.TimeToCompleteQuantity.HasValue)
            {

                TimeSpan ts = TimeSpan.Zero;
                switch (template.TimeToCompleteTimeSpan.Value)
                {
                    case TimeSpanIntervals.Minutes: ts = TimeSpan.FromMinutes(template.TimeToCompleteQuantity.Value); break;
                    case TimeSpanIntervals.Hours: ts = TimeSpan.FromHours(template.TimeToCompleteQuantity.Value); break;
                    case TimeSpanIntervals.Days: ts = TimeSpan.FromDays(template.TimeToCompleteQuantity.Value); break;
                }

                dueDate = DateTime.UtcNow.Add(ts).ToJSONString();
            }

            string statusDueDate = null;
            if (EntityHeader.IsNullOrEmpty(defaultState.TimeAllowedInStatusTimeSpan) &&
                defaultState.TimeAllowedInStatusTimeSpan.Value != TimeSpanIntervals.NotApplicable &&
                defaultState.TimeAllowedInStatusQuantity.HasValue)
            {
                TimeSpan ts = TimeSpan.Zero;
                switch (defaultState.TimeAllowedInStatusTimeSpan.Value)
                {
                    case TimeSpanIntervals.Minutes: ts = TimeSpan.FromMinutes(defaultState.TimeAllowedInStatusQuantity.Value); break;
                    case TimeSpanIntervals.Hours: ts = TimeSpan.FromHours(defaultState.TimeAllowedInStatusQuantity.Value); break;
                    case TimeSpanIntervals.Days: ts = TimeSpan.FromDays(defaultState.TimeAllowedInStatusQuantity.Value); break;
                }

                statusDueDate = DateTime.UtcNow.Add(ts).ToJSONString();
            }

            Console.WriteLine("+++5");

            var ticket = new ServiceTicket()
            {
                Key = template.Key,
                TicketId = ticketId,
                DeviceRepo = EntityHeader.Create(repo.Id, repo.Name),
                CreationDate = currentTimeStamp,
                LastUpdatedDate = currentTimeStamp,
                DueDate = dueDate,
                Name = $"{template.Name} ({device.DeviceId})",
                Address = device.Address,
                IsClosed = false,
                Description = template.Description,
                Subject = String.IsNullOrEmpty(createServiceTicketRequest.Subject) ? $"{template.Name} ({device.DeviceId})" : createServiceTicketRequest.Subject,
                AssignedTo = assignedToUser,
                Template = new EntityHeader<ServiceTicketTemplate>() { Id = template.Id, Text = template.Name },
                ServiceBoard = boardEH,
                Device = new EntityHeader<IoT.DeviceManagement.Core.Models.Device>() { Id = device.Id, Text = device.Name },
                Status = EntityHeader.Create(defaultState.Key, defaultState.Name),
                StatusDate = DateTime.UtcNow.ToJSONString(),
                OwnerOrganization = template.OwnerOrganization,
                HoursEstimate = template.HoursEstimate,
                CostEstimate = template.CostEstimate,
                SkillLevel = template.SkillLevel,
                Urgency = template.Urgency,
                Tools = template.Tools,
                PartsKits = template.PartsKits,
                ServiceParts = template.ServiceParts,
                Instructions = template.Instructions,
                StatusType = template.StatusType,
                StatusDueDate = statusDueDate,
                Resources = template.Resources,
                TroubleshootingSteps = template.TroubleshootingSteps,
                CreatedBy = user,
                LastUpdatedBy = user
            };

            ticket.StatusType.Value = stateSet;

            ticket.History.Add(new ServiceTicketStatusHistory()
            {
                AddedBy = user,
                DateStamp = DateTime.UtcNow.ToJSONString(),
                Status = ticket.Status.Text,
                Note = $"Created service ticket with {defaultState.Name} status."
            });

            Console.WriteLine("+++6");

            ticket.Notes.Add(new ServiceTicketNote()
            {
                AddedBy = user,
                DateStamp = currentTimeStamp,
                Note = assignedToUser != null ? $"Service ticket created and assigned to {assignedToUser.Text}." : "Service ticket created and not assigned to technician."
            });

            if (!String.IsNullOrEmpty(createServiceTicketRequest.Details))
            {
                ticket.Notes.Add(new ServiceTicketNote()
                {
                    Id = Guid.NewGuid().ToString(),
                    Note = createServiceTicketRequest.Details,
                    AddedBy = ticket.CreatedBy,
                    DateStamp = DateTime.UtcNow.ToJSONString()
                });
            }

            Console.WriteLine("+++7");


            await _repo.AddServiceTicketAsync(ticket);

            Console.WriteLine("+++8");

            await SendTicketNotificationAsync(ticket);

            Console.WriteLine("+++9");

            return InvokeResult<string>.Create(ticket.TicketId);
        }

        public async Task<InvokeResult> CloseServiceTicketAsync(string id, EntityHeader org, EntityHeader user)
        {
            var serviceTicket = await _repo.GetServiceTicketAsync(id);

            await AuthorizeAsync(serviceTicket, AuthorizeResult.AuthorizeActions.Create, user, org);

            if (serviceTicket.IsClosed)
            {
                return InvokeResult.FromError("Service ticket is already closed.");
            }

            serviceTicket.IsClosed = true;
            serviceTicket.ClosedBy = user;

            await _repo.UpdateServiceTicketAsync(serviceTicket);

            return InvokeResult.Success;
        }

        public async Task<InvokeResult> DeleteServiceTicketAsync(string id, EntityHeader org, EntityHeader user)
        {
            var ticket = await _repo.GetServiceTicketAsync(id);
            await AuthorizeAsync(ticket, AuthorizeResult.AuthorizeActions.Delete, user, org);
            await _repo.DeleteServiceTicketAsync(id);

            return InvokeResult.Success;
        }

        public async Task<InvokeResult<ServiceTicket>> SetAssignedToAsync(string id, EntityHeader assignedTouser, EntityHeader org, EntityHeader user)
        {
            var ticket = await _repo.GetServiceTicketAsync(id);
            await AuthorizeAsync(ticket, AuthorizeResult.AuthorizeActions.Update, user, org);

            var existingAssigned = EntityHeader.IsNullOrEmpty(ticket.AssignedTo) ? "unassigned" : ticket.AssignedTo.Text;
            var newAssigned = EntityHeader.IsNullOrEmpty(assignedTouser) ? "unassigned" : assignedTouser.Text;

            var historyItem = new ServiceTicketStatusHistory()
            {
                AddedBy = user,
                DateStamp = DateTime.UtcNow.ToJSONString(),
                Status = ticket.Status.Text,
                Note = $"Ticket assigned from [{existingAssigned}] to [{newAssigned}]"
            };

            ticket.History.Insert(0, historyItem);

            ticket.AssignedTo = assignedTouser;
            await _repo.UpdateServiceTicketAsync(ticket);

            return InvokeResult<ServiceTicket>.Create(ticket);
        }

        public async Task<ServiceTicket> GetServiceTicketAsync(string id, EntityHeader org, EntityHeader user)
        {
            Console.WriteLine("Starting getting ticket");
            Console.WriteLine("=====================================");

            var sw = Stopwatch.StartNew();
            var ticket = await _repo.GetServiceTicketAsync(id);

            Console.WriteLine("Loaded service ticket: " + sw.Elapsed.TotalMilliseconds);

            await AuthorizeAsync(ticket, AuthorizeResult.AuthorizeActions.Read, user, org);

            Console.WriteLine("Authorized: " + sw.Elapsed.TotalMilliseconds);
            var sw2 = Stopwatch.StartNew();
            if (!EntityHeader.IsNullOrEmpty(ticket.DeviceRepo))
            {
                var repo = await _repoManager.GetDeviceRepositoryWithSecretsAsync(ticket.DeviceRepo.Id, org, user);
                Console.WriteLine("Loaded device repo: " + sw2.Elapsed.TotalMilliseconds);
                sw2 = Stopwatch.StartNew();
                if (!EntityHeader.IsNullOrEmpty(ticket.Device))
                {
                    ticket.Device.Value = await _deviceManager.GetDeviceByIdAsync(repo, ticket.Device.Id, org, user, true);
                }

                Console.WriteLine("Device load time: " + sw2.Elapsed.TotalMilliseconds);
            }

            var statusType = await _ticketStatusRepo.GetTicketStatusDefinitionAsync(ticket.StatusType.Id);

            ticket.StatusType = EntityHeader<TicketStatusDefinition>.Create(statusType);

            if (!EntityHeader.IsNullOrEmpty(ticket.ServiceBoard))
            {
                ticket.ServiceBoard.Value = await _serviceBoardRepo.GetServiceBoardAsync(ticket.ServiceBoard.Id);
            }

            Console.WriteLine("Loaded board: " + sw.Elapsed.TotalMilliseconds);

            if (!EntityHeader.IsNullOrEmpty(ticket.Template))
            {
                ticket.Template.Value = await _templateRepo.GetServiceTicketTemplateAsync(ticket.Template.Id);

                if (!EntityHeader.IsNullOrEmpty(ticket.Template.Value.TemplateCategory))
                {
                    ticket.Template.Value.TemplateCategory.Value = await _templateCategoryRepo.GetTemplateCategoryAsync(ticket.Template.Value.TemplateCategory.Id);
                }
            }

            Console.WriteLine("Total load time: " + sw.Elapsed.TotalMilliseconds);

            if (!ticket.IsViewed && !EntityHeader.IsNullOrEmpty(ticket.AssignedTo) && ticket.AssignedTo.Id == user.Id)
            {
                ticket.IsViewed = true;
                ticket.ViewedBy = user;
                ticket.ViewedDate = DateTime.UtcNow.ToJSONString();
                var history = new ServiceTicketStatusHistory()
                {
                    AddedBy = user,
                    DateStamp = ticket.ViewedDate,
                    Status = ticket.Status.Text,
                    Note = $"Viewed by [{user.Text}]"
                };

                ticket.History.Insert(0, history);
                await _repo.UpdateServiceTicketAsync(ticket);
            }

            return ticket;
        }

        public async Task<ListResponse<ServiceTicketSummary>> GetClosedServiceTicketAsync(ListRequest listRequest, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org, typeof(ServiceTicket));

            return await _repo.GetClosedTicketsAsyncAsync(org.Id, listRequest);
        }

        public async Task<ListResponse<ServiceTicketSummary>> GetOpenServiceTicketAsync(ListRequest listRequest, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org, typeof(ServiceTicket));

            return await _repo.GetOpenTicketsAsyncAsync(org.Id, listRequest);
        }

        public async Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsForOrgAsync(ListRequest listRequest, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org, typeof(ServiceTicket));

            return await _repo.GetTicketsForOrgAsync(org.Id, listRequest);
        }

        public async Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsByStatusAsync(string statusId, ListRequest listRequest, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org, typeof(ServiceTicket));

            return await _repo.GetTicketsWithStatusAsync(statusId, org.Id, listRequest);
        }

        public async Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsForDeviceAsync(string deviceId, ListRequest listRequest, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org, typeof(ServiceTicket));

            return await _repo.GetTicketForDeviceAsync(deviceId, org.Id, listRequest);
        }


        public async Task<InvokeResult> UpdateServiceTicketAsync(ServiceTicket serviceTicket, EntityHeader org, EntityHeader user)
        {
            ValidationCheck(serviceTicket, Actions.Update);

            serviceTicket.LastUpdatedBy = user;
            serviceTicket.LastUpdatedDate = DateTime.UtcNow.ToJSONString();

            await AuthorizeAsync(serviceTicket, AuthorizeResult.AuthorizeActions.Create, user, org);
            await _repo.UpdateServiceTicketAsync(serviceTicket);


            return InvokeResult.Success;
        }

        public async Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsByUserAsync(string userId, ListRequest listRequest, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org, typeof(ServiceTicket));

            return await _repo.GetServiceTicketsByUserAsync(userId, org.Id, listRequest);
        }

        public async Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsByTemplateAsync(string templateId, ListRequest listRequest, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org, typeof(ServiceTicket));

            return await _repo.GetTicketsWithStatusAsync(templateId, org.Id, listRequest);
        }

        public async Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsAsync(TicketFilter filter, ListRequest listRequest, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org, typeof(ServiceTicket));

            return await _repo.GetServiceTicketsAsync(filter, org.Id, listRequest);
        }

        public async Task<InvokeResult<ServiceTicket>> SetTicketStatusAsync(string id, EntityHeader newStatus, EntityHeader org, EntityHeader user)
        {
            var date = DateTime.UtcNow.ToJSONString();

            var ticket = await _repo.GetServiceTicketAsync(id);
            if (newStatus.Id == ticket.Status.Id)
            {
                return InvokeResult<ServiceTicket>.FromError($"Already in {newStatus}");
            }

            await AuthorizeAsync(ticket, AuthorizeResult.AuthorizeActions.Update, user, org, "SetStatus");

            var history = new ServiceTicketStatusHistory()
            {
                AddedBy = user,
                DateStamp = date,
                Status = newStatus.Text,
                Note = $"Status changed from [{ticket.Status.Text}] to [{newStatus.Text}]"
            };
            ticket.History.Insert(0, history);

            var statusDefinition = await _ticketStatusRepo.GetTicketStatusDefinitionAsync(ticket.StatusType.Id);
            var status = statusDefinition.Items.First(stat => stat.Key == newStatus.Id);

            if (!EntityHeader.IsNullOrEmpty(status.TimeAllowedInStatusTimeSpan) &&
                status.TimeAllowedInStatusTimeSpan.Value != TimeSpanIntervals.NotApplicable &&
                status.TimeAllowedInStatusQuantity.HasValue)
            {
                TimeSpan ts = TimeSpan.Zero;
                switch (status.TimeAllowedInStatusTimeSpan.Value)
                {
                    case TimeSpanIntervals.Minutes: ts = TimeSpan.FromMinutes(status.TimeAllowedInStatusQuantity.Value); break;
                    case TimeSpanIntervals.Hours: ts = TimeSpan.FromHours(status.TimeAllowedInStatusQuantity.Value); break;
                    case TimeSpanIntervals.Days: ts = TimeSpan.FromDays(status.TimeAllowedInStatusQuantity.Value); break;
                }

                ticket.StatusDueDate = DateTime.UtcNow.Add(ts).ToJSONString();

                history = new ServiceTicketStatusHistory()
                {
                    AddedBy = user,
                    DateStamp = date,
                    Status = newStatus.Text,
                    StatusDueDate = ticket.StatusDueDate,
                    Note = $"New status due date set to [{ticket.StatusDueDate.ToDateTime().ToLocalTime()}]"
                };
                ticket.History.Insert(0, history);
            }
            else
            {
                ticket.StatusDueDate = null;
            }

            if (status.IsClosed != ticket.IsClosed)
            {
                ticket.IsClosed = status.IsClosed;
                ticket.ClosedDate = ticket.IsClosed ? date : null;
                ticket.ClosedBy = user;

                history = new ServiceTicketStatusHistory()
                {
                    AddedBy = user,
                    DateStamp = date,
                    Status = newStatus.Text,
                    Note = ticket.IsClosed ? $"Closed by [{user.Text}]" : $"Reopened by [{user.Text}]"
                };

                ticket.History.Insert(0, history);
            }

            ticket.Status = newStatus;
            ticket.StatusDate = date;

            ticket.LastUpdatedBy = user;
            ticket.LastUpdatedDate = date;

            await _repo.UpdateServiceTicketAsync(ticket);

            return InvokeResult<ServiceTicket>.Create(ticket);
        }

        public async Task<InvokeResult<ServiceTicket>> SetTicketViewedStatusAsync(string id, bool viewed, EntityHeader org, EntityHeader user)
        {
            var ticket = await _repo.GetServiceTicketAsync(id);
            var date = DateTime.UtcNow.ToJSONString();

            await AuthorizeAsync(ticket, AuthorizeResult.AuthorizeActions.Update, user, org, "SetViewStatus");

            if (viewed == ticket.IsViewed)
            {
                return InvokeResult<ServiceTicket>.FromError(viewed ? $"Aleady been marked as viewed." : "Already been marked as not viewed");
            }

            ticket.IsViewed = viewed;
            if (viewed)
            {
                if (!EntityHeader.IsNullOrEmpty(ticket.AssignedTo) && user.Id != ticket.AssignedTo.Id)
                {
                    return InvokeResult<ServiceTicket>.FromError($"Assigned to {ticket.AssignedTo.Text} but attempted to be viewed by {user.Text}.  Only the assigned user can mark as viewed.");
                }

                ticket.ViewedDate = DateTime.UtcNow.ToJSONString();
                ticket.ViewedBy = user;

                var history = new ServiceTicketStatusHistory()
                {
                    AddedBy = user,
                    DateStamp = date,
                    Status = ticket.Status.Text,
                    Note = $"Viewed by [{user.Text}]"
                };
                ticket.History.Insert(0, history);
            }
            else
            {
                ticket.ViewedDate = null;
                ticket.ViewedBy = null;

                var history = new ServiceTicketStatusHistory()
                {
                    AddedBy = user,
                    DateStamp = date,
                    Status = ticket.Status.Text,
                    Note = $"Cleared viewed by [{user.Text}]"
                };
                ticket.History.Insert(0, history);
            }

            ticket.LastUpdatedBy = user;
            ticket.LastUpdatedDate = date;
            await _repo.UpdateServiceTicketAsync(ticket);

            return InvokeResult<ServiceTicket>.Create(ticket);
        }

        public async Task<InvokeResult<ServiceTicket>> SetTicketClosedStatusAsync(string id, bool isClosed, EntityHeader org, EntityHeader user)
        {
            var ticket = await _repo.GetServiceTicketAsync(id);
            var date = DateTime.UtcNow.ToJSONString();

            await AuthorizeAsync(ticket, AuthorizeResult.AuthorizeActions.Update, user, org, "SetClosedStatus");

            if (isClosed == ticket.IsClosed)
            {
                return InvokeResult<ServiceTicket>.FromError(isClosed ? $"Aleady been marked as closed." : "Already been marked as not closed");
            }

            ticket.IsClosed = isClosed;
            if (isClosed)
            {
                ticket.ClosedDate = DateTime.UtcNow.ToJSONString();
                ticket.ClosedBy = user;

                var history = new ServiceTicketStatusHistory()
                {
                    AddedBy = user,
                    DateStamp = date,
                    Status = ticket.Status.Text,
                    Note = $"Closed by [{user.Text}]"
                };
                ticket.History.Insert(0, history);
            }
            else
            {
                ticket.ClosedDate = null;
                ticket.ClosedBy = null;

                var history = new ServiceTicketStatusHistory()
                {
                    AddedBy = user,
                    DateStamp = date,
                    Status = ticket.Status.Text,
                    Note = $"Re-opened by [{user.Text}]"
                };
                ticket.History.Insert(0, history);
            }

            ticket.LastUpdatedBy = user;
            ticket.LastUpdatedDate = date;
            await _repo.UpdateServiceTicketAsync(ticket);

            return InvokeResult<ServiceTicket>.Create(ticket);
        }

        public async Task<InvokeResult<ServiceTicket>> AddTicketNoteAsync(string ticketId, ServiceTicketNote ticketNote, EntityHeader org, EntityHeader user)
        {
            if (string.IsNullOrEmpty(ticketId)) throw new ArgumentNullException(nameof(ticketId));
            if (org == null) throw new ArgumentNullException(nameof(org));
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (ticketNote == null) throw new ArgumentNullException(nameof(ticketNote));

            var ticket = await _repo.GetServiceTicketAsync(ticketId);

            await AuthorizeAsync(ticket, AuthorizeResult.AuthorizeActions.Update, user, org, "AddNote");

            ValidationCheck(ticketNote, Actions.Create);

            ticket.Notes.Add(ticketNote);
            ticket.LastUpdatedBy = user;
            ticket.LastUpdatedDate = ticketNote.DateStamp;
            await _repo.UpdateServiceTicketAsync(ticket);

            return InvokeResult<ServiceTicket>.Create(ticket);
        }

        public async Task<ListResponse<ServiceTicketSummary>> GetTicketsForBoardAsync(string boardId, ListRequest listRequest, EntityHeader org, EntityHeader user)
        {
            if (string.IsNullOrEmpty(boardId)) throw new ArgumentNullException(nameof(boardId));
            if (org == null) throw new ArgumentNullException(nameof(org));
            if (user == null) throw new ArgumentNullException(nameof(user));

            await AuthorizeOrgAccessAsync(user, org, typeof(ServiceTicket));

            return await _repo.GetTicketsForBoardAsync(boardId, listRequest);
        }

        public async Task<InvokeResult> ClearDeviceExceptionAsync(DeviceException exception, EntityHeader org, EntityHeader user)
        {
            if (exception == null) throw new ArgumentNullException(nameof(exception));
            if (org == null) throw new ArgumentNullException(nameof(org));
            if (user == null) throw new ArgumentNullException(nameof(user));

            var repo = await _repoManager.GetDeviceRepositoryWithSecretsAsync(exception.DeviceRepositoryId, org, user);
            var device = await _deviceManager.GetDeviceByIdAsync(repo, exception.DeviceId, org, user);
            var deviceConfig = await _deviceConfigManager.GetDeviceConfigurationAsync(device.DeviceConfiguration.Id, org, user);

            var deviceErrorCode = deviceConfig.ErrorCodes.FirstOrDefault(err => err.Key == exception.ErrorCode);
            if (deviceErrorCode == null)
            {
                return InvokeResult.FromError($"Could not find error code [{exception.ErrorCode}] on device configuration [{deviceConfig.Name}] for device [{device.Name}]");
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Clear Device Exception.");

            if (!EntityHeader.IsNullOrEmpty(deviceErrorCode.ServiceTicketTemplate))
            {
                var tickets = await _repo.GetOpenTicketOnDeviceAsync(device.Id, deviceErrorCode.ServiceTicketTemplate.Id, org.Id);
                foreach (var ticket in tickets)
                {
                    ticket.IsClosed = true;
                    ticket.ClosedBy = user;

                    await _repo.UpdateServiceTicketAsync(ticket);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No service ticket, skipping.");
            }

            if (!EntityHeader.IsNullOrEmpty(deviceErrorCode.DistroList))
            {
                var distroList = await _distroManager.GetListAsync(deviceErrorCode.DistroList.Id, org, user);
                var subject = "[CLEARED] -" + (String.IsNullOrEmpty(deviceErrorCode.EmailSubject) ? deviceErrorCode.Name : deviceErrorCode.EmailSubject.Replace("[DEVICEID]", device.DeviceId).Replace("[DEVICENAME]", device.Name));

                foreach (var notificationUser in distroList.AppUsers)
                {
                    var appUser = await _userManager.FindByIdAsync(notificationUser.Id);
                    if (deviceErrorCode.SendEmail)
                    {
                        var body = $"The error code [{deviceErrorCode.Key}] was cleared on the device {device.Name}<br>{deviceErrorCode.Description}<br>{exception.Details}";
                        await _emailSender.SendAsync(appUser.Email, subject, body);
                    }

                    if (deviceErrorCode.SendSMS)
                    {
                        var body = $"Device {device.Name} cleared error code [${deviceErrorCode.Key}] {deviceErrorCode.Description} {exception.Details}";
                        await _smsSender.SendAsync(appUser.PhoneNumber, body);
                    }
                }
            }
            else
            {
                Console.WriteLine("No distro, skipping.");
            }

            Console.ResetColor();


            return InvokeResult.Success;
        }

        public async Task<InvokeResult> HandleDeviceExceptionAsync(DeviceException exception, EntityHeader org, EntityHeader user)
        {
            if (exception == null) throw new ArgumentNullException(nameof(exception));
            if (org == null) throw new ArgumentNullException(nameof(org));
            if (user == null) throw new ArgumentNullException(nameof(user));

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Handling Device Exception.");

            var repo = await _repoManager.GetDeviceRepositoryWithSecretsAsync(exception.DeviceRepositoryId, org, user);
            var device = await _deviceManager.GetDeviceByDeviceIdAsync(repo, exception.DeviceId, org, user);
            var deviceConfig = await _deviceConfigManager.GetDeviceConfigurationAsync(device.DeviceConfiguration.Id, org, user);

            var deviceErrorCode = deviceConfig.ErrorCodes.FirstOrDefault(err => err.Key == exception.ErrorCode);
            if (deviceErrorCode == null)
            {
                return InvokeResult.FromError($"Could not find error code [{exception.ErrorCode}] on device configuration [{deviceConfig.Name}] for device [{device.Name}]");
            }

            if (!EntityHeader.IsNullOrEmpty(deviceErrorCode.ServiceTicketTemplate))
            {
                Console.WriteLine("Generating service ticket (every occurence.");
                var request = new CreateServiceTicketRequest()
                {
                    TemplateId = deviceErrorCode.ServiceTicketTemplate.Id,
                    DeviceId = device.DeviceId,
                    Details = exception.Details,
                    DontCreateIfOpenForDevice = !deviceErrorCode.TriggerOnEachOccurrence,
                    RepoId = repo.Id
                };

                var result = await CreateServiceTicketAsync(request, org, user);
                if (!result.Successful) return result.ToInvokeResult();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No service ticket, skipping.");
            }

            if (!EntityHeader.IsNullOrEmpty(deviceErrorCode.DistroList))
            {
                var deviceError = device.Errors.Where(err => err.DeviceErrorCode == exception.ErrorCode).FirstOrDefault();

                if (String.IsNullOrEmpty(deviceError.NextNotification) || (deviceError.NextNotification.ToDateTime().ToUniversalTime() < DateTime.UtcNow))
                {
                    var result = await _distroManager.GetListAsync(deviceErrorCode.DistroList.Id, org, user);
                    var subject = String.IsNullOrEmpty(deviceErrorCode.EmailSubject) ? deviceErrorCode.Name : deviceErrorCode.EmailSubject.Replace("[DEVICEID]", device.DeviceId).Replace("[DEVICENAME]", device.Name);

                    foreach (var notificationUser in result.AppUsers)
                    {
                        var appUser = await _userManager.FindByIdAsync(notificationUser.Id);
                        if (deviceErrorCode.SendEmail)
                        {
                            var body = $"The error code [{deviceErrorCode.Key}] was detected on the device {device.Name}<br>{deviceErrorCode.Description}<br>{exception.Details}";
                            if(exception.AdditionalDetails.Any())
                            {
                                body += "<br>";
                                body += "<b>Additional Details:<br /><b>";
                                body += "<ul>";
                                foreach (var detail in exception.AdditionalDetails)
                                    body += $"<li>{detail}</li>";

                                body += "</ul>";
                            }
                            await _emailSender.SendAsync(appUser.Email, subject, body);
                        }

                        if (deviceErrorCode.SendSMS)
                        {
                            var body = $"Device {device.Name} generated error code [${deviceErrorCode.Key}] {deviceErrorCode.Description} {exception.Details}";
                            await _smsSender.SendAsync(appUser.PhoneNumber, body);
                        }
                    }

                    if (EntityHeader.IsNullOrEmpty(deviceErrorCode.NotificationIntervalTimeSpan))
                    {
                        deviceError.NextNotification = null;
                    }
                    else if (deviceErrorCode.NotificationIntervalQuantity.HasValue && deviceErrorCode.NotificationIntervalTimeSpan.Value != TimeSpanIntervals.NotApplicable)
                    {

                        deviceError.NextNotification = deviceErrorCode.NotificationIntervalTimeSpan.Value.AddTimeSpan(deviceErrorCode.NotificationIntervalQuantity.Value);
                    }
                    else
                    {
                        deviceError.NextNotification = null;
                        Logger.AddCustomEvent(Core.PlatformSupport.LogLevel.Error, "ServiceTicketManager__HandleDeviceExceptionAsync", "Invalid quantity on NotificationIntervalQuantity", device.DeviceId.ToKVP("deviceId"), exception.ErrorCode.ToKVP("errorCode"));
                    }
                }
                else
                {
                    if (String.IsNullOrEmpty(deviceError.NextNotification))
                    {
                        Console.WriteLine("NExt Notification is null....");
                    }
                    else
                    {
                        Console.WriteLine("When to send next notification: " + deviceError.NextNotification);
                    }
                }
            }
            else
            {

                Console.WriteLine("No distro, skipping.");
            }

            Console.ResetColor();

            await _deviceManager.UpdateDeviceAsync(repo, device, org, user);

            return InvokeResult.Success;
        }

        private String GetWebURI()
        {
            var environment = AppConfig.WebAddress;
            if (AppConfig.WebAddress.ToLower().Contains("api"))
            {
                switch (AppConfig.Environment)
                {
                    case Environments.Development: environment = "https://dev.nuviot.com"; break;
                    case Environments.Testing: environment = "https://test.nuviot.com"; break;
                    case Environments.Beta: environment = "https://qa.nuviot.com"; break;
                    case Environments.Staging: environment = "https://stage.nuviot.com"; break;
                    case Environments.Production: environment = "https://www.nuviot.com"; break;
                    case Environments.Local:
                    case Environments.LocalDevelopment: environment = "http://localhost:5000"; break;
                }
            }

            return environment;
        }

        private string GetTicketNotificationContent(ServiceTicket ticket)
        {
            var redirectUri = $"{GetWebURI()}/home/links?viewtype=fsliteticket&viewid={ticket.Id}";

            var bldr = new StringBuilder();
            bldr.AppendLine("You have been assigned to a service ticket<br />");

            bldr.AppendLine($"<h4>{ticket.Subject}<h4 />");
            bldr.AppendLine($"<p>{ticket.Description}</p>");

            bldr.AppendLine($"Click <a href='{redirectUri}'>here</a> for more information.");

            return bldr.ToString();
        }

        public async Task<InvokeResult> SendTicketNotificationAsync(string ticketId, EntityHeader org, EntityHeader user)
        {
            var ticket = await _repo.GetServiceTicketAsync(ticketId);
            await AuthorizeAsync(ticket, AuthorizeResult.AuthorizeActions.Update, user, org, "SendTicketNotification");
            return await SendTicketNotificationAsync(ticket);
        }

        public async Task<InvokeResult> SendTicketRemindersAsync()
        {
            var ticketSummaries = await _repo.FindTicketsForNotificationRemindersAsync();
            foreach (var ticketSummary in ticketSummaries)
            {
                var ticket = await _repo.GetServiceTicketAsync(ticketSummary.Id);
                await SendTicketNotificationAsync(ticket);
            }

            return InvokeResult.Success;
        }

        public async Task<InvokeResult> SendTicketNotificationAsync(ServiceTicket ticket)
        {
            var template = await _templateRepo.GetServiceTicketTemplateAsync(ticket.Template.Id);

            var contents = GetTicketNotificationContent(ticket);
            if (!EntityHeader.IsNullOrEmpty(ticket.AssignedTo))
            {
                var user = await _userManager.FindByIdAsync(ticket.AssignedTo.Id);

                await _emailSender.SendAsync(user.Email, $"Service Ticket #{ticket.TicketId}", contents);

                ticket.NotificationHistory.Insert(0, new TicketNotification()
                {
                    NotifiedUser = ticket.AssignedTo,
                    Timestamp = DateTime.UtcNow.ToJSONString()
                });

                ticket.LastNotification = DateTime.UtcNow.ToJSONString();
                ticket.LastNotifiedUser = ticket.AssignedTo;

                switch (template.OpenReminderNotificationTimeSpan.Value)
                {
                    case TimeSpanIntervals.Days:
                        ticket.NextNotification = DateTime.UtcNow.AddDays(template.OpenReminderNotificationQuantity.Value).ToJSONString();
                        break;
                    case TimeSpanIntervals.Hours:
                        ticket.NextNotification = DateTime.UtcNow.AddHours(template.OpenReminderNotificationQuantity.Value).ToJSONString();
                        break;
                    case TimeSpanIntervals.Minutes:
                        ticket.NextNotification = DateTime.UtcNow.AddMinutes(template.OpenReminderNotificationQuantity.Value).ToJSONString();
                        break;
                    case TimeSpanIntervals.NotApplicable:
                        ticket.NextNotification = null;
                        break;
                }
            }

            return InvokeResult.Success;
        }
    }
}
