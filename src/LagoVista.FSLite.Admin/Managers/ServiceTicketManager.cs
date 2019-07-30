using LagoVista.Core.Interfaces;
using LagoVista.Core.Managers;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Admin.Interfaces;
using LagoVista.FSLite.Models;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.IoT.DeviceManagement.Core;
using LagoVista.IoT.Logging.Loggers;
using System.Threading.Tasks;
using System.Linq;
using System;
using LagoVista.IoT.Deployment.Admin.Interfaces;
using LagoVista.Core;
using LagoVista.IoT.DeviceManagement.Core.Managers;
using LagoVista.IoT.Deployment.Admin;
using LagoVista.IoT.Deployment.Admin.Repos;
using System.Diagnostics;
using System.Collections.Generic;

namespace LagoVista.FSLite.Admin.Managers
{
    public class ServiceTicketManager : ManagerBase, IServiceTicketManager, IServiceTicketCreator
    {
        IServiceTicketRepo _repo;
        IDeviceManager _deviceManager;
        IServiceTicketTemplateRepo _templateRepo;
        IServiceBoardRepo _serviceBoardRepo;
        IDeviceRepositoryManager _repoManager;
        ITicketStatusRepo _ticketStatusRepo;
        ITemplateCategoryRepo _templateCategoryRepo;
        IDeviceConfigurationRepo _deviceConfigRepo;

        public ServiceTicketManager(IServiceTicketRepo repo, IServiceBoardRepo boardRepo, IDeviceRepositoryManager repoManager, IDeviceManager deviceManager, ITemplateCategoryRepo templateCategoryRepo,
                                    IDeviceConfigurationRepo deviceConfigRepo, IAppConfig appConfig, IAdminLogger logger, ITicketStatusRepo ticketStatusRepo, IServiceTicketTemplateRepo templateRepo, IDependencyManager depmanager, ISecurity security)
            : base(logger, appConfig, depmanager, security)
        {
            _repo = repo;
            _serviceBoardRepo = boardRepo;
            _repoManager = repoManager;
            _deviceManager = deviceManager;
            _templateRepo = templateRepo;
            _ticketStatusRepo = ticketStatusRepo;
            _templateCategoryRepo = templateCategoryRepo;
            _deviceConfigRepo = deviceConfigRepo;
        }

        public async Task<InvokeResult> AddServiceTicketAsync(ServiceTicket serviceTicket, EntityHeader org, EntityHeader user)
        {
            ValidationCheck(serviceTicket, Actions.Create);

            await AuthorizeAsync(serviceTicket, AuthorizeResult.AuthorizeActions.Create, user, org);
            await _repo.AddServiceTicketAsync(serviceTicket);

            return InvokeResult.Success;
        }

        public async Task<InvokeResult<string>> CreateServiceTicketAsync(string ticketTemplateId, string deviceRepoId, string deviceId)
        {
            var ticket = await CreateServiceTicketAsync(new CreateServiceTicketRequest()
            {
                DeviceId = deviceId,
                RepoId = deviceRepoId,
                TemplateId = ticketTemplateId
            });

            return InvokeResult<string>.Create(ticket.Result.TicketId);
        }

        public async Task<InvokeResult<ServiceTicket>> CreateServiceTicketAsync(CreateServiceTicketRequest request, EntityHeader org = null, EntityHeader user = null)
        {
            if (String.IsNullOrEmpty(request.RepoId)) throw new NullReferenceException("RepoId");
            if (String.IsNullOrEmpty(request.DeviceId)) throw new NullReferenceException("DeviceId");
            if (String.IsNullOrEmpty(request.TemplateId)) throw new NullReferenceException("TemplateId");

            var template = await _templateRepo.GetServiceTicketTemplateAsync(request.TemplateId);
            org = org ?? template.OwnerOrganization;
            user = user ?? template.DefaultContact ?? template.CreatedBy;

            if (org == null) throw new NullReferenceException(nameof(org));
            if (user == null) throw new NullReferenceException(nameof(user));

            var repo = await _repoManager.GetDeviceRepositoryWithSecretsAsync(request.RepoId, org, user);
            if (repo == null)
            {
                throw new InvalidOperationException($"Could not find repository for id {request.RepoId}");
            }

            if (org != null && template.OwnerOrganization != org)
            {
                throw new InvalidOperationException("Template, org mismatch.");
            }

            var device = await _deviceManager.GetDeviceByIdAsync(repo, request.DeviceId, template.OwnerOrganization, user ?? template.DefaultContact);

            if (org != null && device.OwnerOrganization != org)
            {
                throw new InvalidOperationException("Device, org mismatch.");
            }

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

            var ticketId = Guid.NewGuid().ToString();

            if (!String.IsNullOrEmpty(request.BoardId))
            {
                var board = await _serviceBoardRepo.GetServiceBoardAsync(request.BoardId);
                boardEH = new EntityHeader<ServiceBoard>() { Id = board.Id, Text = board.Name };
                var ticketNumber = await _serviceBoardRepo.GetNextTicketNumber(request.BoardId);
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

            string dueDate = null;

            if (!EntityHeader.IsNullOrEmpty(template.TimeToCompleteTimeSpan) &&
                template.TimeToCompleteTimeSpan.Value != TimeToCompleteTimeSpans.NotApplicable &&
                template.TimeToCompleteQuantity.HasValue)
            {

                TimeSpan ts;
                switch (template.TimeToCompleteTimeSpan.Value)
                {
                    case TimeToCompleteTimeSpans.Minutes: ts = TimeSpan.FromMinutes(template.TimeToCompleteQuantity.Value); break;
                    case TimeToCompleteTimeSpans.Hours: ts = TimeSpan.FromHours(template.TimeToCompleteQuantity.Value); break;
                    case TimeToCompleteTimeSpans.Days: ts = TimeSpan.FromDays(template.TimeToCompleteQuantity.Value); break;
                }

                dueDate = DateTime.UtcNow.Add(ts).ToJSONString();
            }

            string statusDueDate = null;
            if (EntityHeader.IsNullOrEmpty(defaultState.TimeAllowedInStatusTimeSpan) &&
                defaultState.TimeAllowedInStatusTimeSpan.Value != TimeToCompleteTimeSpans.NotApplicable &&
                defaultState.TimeAllowedInStatusQuantity.HasValue)
            {
                TimeSpan ts;
                switch (defaultState.TimeAllowedInStatusTimeSpan.Value)
                {
                    case TimeToCompleteTimeSpans.Minutes: ts = TimeSpan.FromMinutes(defaultState.TimeAllowedInStatusQuantity.Value); break;
                    case TimeToCompleteTimeSpans.Hours: ts = TimeSpan.FromHours(defaultState.TimeAllowedInStatusQuantity.Value); break;
                    case TimeToCompleteTimeSpans.Days: ts = TimeSpan.FromDays(defaultState.TimeAllowedInStatusQuantity.Value); break;
                }

                statusDueDate = DateTime.UtcNow.Add(ts).ToJSONString();
            }

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
                Subject = String.IsNullOrEmpty(request.Subject) ? $"{template.Name} ({device.DeviceId})" : request.Subject,
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
            }); ;

            ticket.Notes.Add(new ServiceTicketNote()
            {
                AddedBy = user,
                DateStamp = currentTimeStamp,
                Note = assignedToUser != null ? $"Service ticket created and assigned to {assignedToUser.Text}." : "Service ticket created and not assigned to technician."
            });

            await _repo.AddServiceTicketAsync(ticket);

            return InvokeResult<ServiceTicket>.Create(ticket);
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
            var sw = Stopwatch.StartNew();
            var ticket = await _repo.GetServiceTicketAsync(id);

            await AuthorizeAsync(ticket, AuthorizeResult.AuthorizeActions.Read, user, org);

            if (!EntityHeader.IsNullOrEmpty(ticket.DeviceRepo))
            {
                var repo = await _repoManager.GetDeviceRepositoryWithSecretsAsync(ticket.DeviceRepo.Id, org, user);
                if (!EntityHeader.IsNullOrEmpty(ticket.Device))
                {
                    ticket.Device.Value = await _deviceManager.GetDeviceByIdAsync(repo, ticket.Device.Id, org, user, true);
                }
            }

            var statusType = await _ticketStatusRepo.GetTicketStatusDefinitionAsync(ticket.StatusType.Id);

            ticket.StatusType = EntityHeader<TicketStatusDefinition>.Create(statusType);

            if (!EntityHeader.IsNullOrEmpty(ticket.ServiceBoard))
            {
                ticket.ServiceBoard.Value = await _serviceBoardRepo.GetServiceBoardAsync(ticket.ServiceBoard.Id);
            }

            if (!EntityHeader.IsNullOrEmpty(ticket.Template))
            {
                ticket.Template.Value = await _templateRepo.GetServiceTicketTemplateAsync(ticket.Template.Id);

                if (!EntityHeader.IsNullOrEmpty(ticket.Template.Value.TemplateCategory))
                {
                    ticket.Template.Value.TemplateCategory.Value = await _templateCategoryRepo.GetTemplateCategoryAsync(ticket.Template.Value.TemplateCategory.Id);
                }
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
            if(newStatus.Id == ticket.Status.Id)
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
                status.TimeAllowedInStatusTimeSpan.Value != TimeToCompleteTimeSpans.NotApplicable &&
                status.TimeAllowedInStatusQuantity.HasValue)
            {
                TimeSpan ts;
                switch (status.TimeAllowedInStatusTimeSpan.Value)
                {
                    case TimeToCompleteTimeSpans.Minutes: ts = TimeSpan.FromMinutes(status.TimeAllowedInStatusQuantity.Value); break;
                    case TimeToCompleteTimeSpans.Hours: ts = TimeSpan.FromHours(status.TimeAllowedInStatusQuantity.Value); break;
                    case TimeToCompleteTimeSpans.Days: ts = TimeSpan.FromDays(status.TimeAllowedInStatusQuantity.Value); break;
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

            if(status.IsClosed != ticket.IsClosed)
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
            if(viewed)
            {
                if(!EntityHeader.IsNullOrEmpty(ticket.AssignedTo) && user.Id != ticket.AssignedTo.Id)
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

        public async Task<InvokeResult<ServiceTicket>> AddTicketNoteAsync(string id, ServiceTicketNote note, EntityHeader org, EntityHeader user)
        {
            var ticket = await _repo.GetServiceTicketAsync(id);

            await AuthorizeAsync(ticket, AuthorizeResult.AuthorizeActions.Update, user, org, "AddNote");

            ValidationCheck(note, Actions.Create);

            ticket.Notes.Add(note);
            ticket.LastUpdatedBy = user;
            ticket.LastUpdatedDate = note.DateStamp;
            await _repo.UpdateServiceTicketAsync(ticket);

            return InvokeResult<ServiceTicket>.Create(ticket);
        }

        public async Task<ListResponse<ServiceTicketSummary>> GetTicketsForBoardAsync(string boardId, ListRequest listRequest, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org, typeof(ServiceTicket));

            return await _repo.GetTicketsForBoardAsync(boardId, listRequest);
        }
    }
}
