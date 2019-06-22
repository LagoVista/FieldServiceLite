using LagoVista.Core.Interfaces;
using LagoVista.Core.Managers;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Admin.Interfaces;
using LagoVista.FSLite.Models;
using LagoVista.IoT.DeviceAdmin.Interfaces.Repos;
using LagoVista.IoT.DeviceManagement.Core;
using LagoVista.IoT.DeviceManagement.Core.Repos;
using LagoVista.IoT.Logging.Loggers;
using System.Threading.Tasks;
using System.Linq;
using System;
using LagoVista.IoT.Deployment.Admin.Interfaces;
using LagoVista.Core;
using LagoVista.IoT.DeviceManagement.Core.Managers;

namespace LagoVista.FSLite.Admin.Managers
{
    public class ServiceTicketManager : ManagerBase, IServiceTicketManager, IServiceTicketCreator
    {
        IServiceTicketRepo _repo;
        IDeviceManager _deviceManager;
        IServiceTicketTemplateRepo _templateRepo;
        IServiceBoardRepo _serviceBoardRepo;
        IDeviceRepositoryManager _repoManager;
        IStateSetRepo _stateSetRepo;

        public ServiceTicketManager(IServiceTicketRepo repo, IServiceBoardRepo boardRepo, IDeviceRepositoryManager repoManager, IDeviceManager deviceManager, IAppConfig appConfig, IAdminLogger logger,
                                    IStateSetRepo stateSetRepo, IServiceTicketTemplateRepo templateRepo, IDependencyManager depmanager, ISecurity security)
            : base(logger, appConfig, depmanager, security)
        {
            _repo = repo;
            _serviceBoardRepo = boardRepo;
            _repoManager = repoManager;
            _deviceManager = deviceManager;
            _templateRepo = templateRepo;
            _stateSetRepo = stateSetRepo;
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
            user = user ?? template.PrimaryContact ?? template.CreatedBy;

            if (org == null) throw new NullReferenceException(nameof(org));
            if (user == null) throw new NullReferenceException(nameof(user));

            var repo = await _repoManager.GetDeviceRepositoryWithSecretsAsync(request.RepoId, org, user);
            if(repo == null)
            {
                throw new InvalidOperationException($"Could not find repository for id {request.RepoId}");
            }


            if (org != null && template.OwnerOrganization != org)
            {
                throw new InvalidOperationException("Template, org mismatch.");
            }

            var device = await _deviceManager.GetDeviceByIdAsync(repo, request.DeviceId, template.OwnerOrganization, user ?? template.PrimaryContact);

            if (org != null && device.OwnerOrganization != org)
            {
                throw new InvalidOperationException("Device, org mismatch.");
            }

            var stateSet = await _stateSetRepo.GetStateSetAsync(template.StatusType.Id);
            var defaultState = stateSet.States.Where(st => st.IsInitialState).First();

            var assignedToUser = device.AssignedUser;
            if (assignedToUser == null)
            {
                assignedToUser = repo.AssignedUser;
            }

            if (assignedToUser == null)
            {
                assignedToUser = template.PrimaryContact;
            }

            var currentTimeStamp = DateTime.UtcNow.ToJSONString();

            var ticket = new ServiceTicket()
            {
                Details = new EntityHeader<ServiceTicketTemplate>() { Id = template.Id, Text = template.Name },
                Key = template.Key,
                CreationDate = currentTimeStamp,
                LastUpdatedDate = currentTimeStamp,
                Name = $"{template.Name} ({device.DeviceId})",
                Address = device.Address,
                IsClosed = false,
                ServiceBoard = repo.ServiceBoard,
                Description = template.Description,
                Subject = String.IsNullOrEmpty(request.Subject) ? $"{template.Name} ({device.DeviceId})" : request.Subject,
                AssignedTo = assignedToUser,
                Device = new EntityHeader<IoT.DeviceManagement.Core.Models.Device>() { Id = device.Id, Text = device.Name },
                Status = EntityHeader.Create(defaultState.Key, defaultState.Name),
                StatusDate = DateTime.UtcNow.ToJSONString(),
                OwnerOrganization = template.OwnerOrganization,
                CreatedBy = user,
                LastUpdatedBy = user 
            };

            if (!EntityHeader.IsNullOrEmpty(ticket.ServiceBoard))
            {
                var board = await _serviceBoardRepo.GetServiceBoardAsync(ticket.ServiceBoard.Id);
                var ticketNumber = await _serviceBoardRepo.GetNextTicketNumber(ticket.ServiceBoard.Id);
                ticket.TicketId = $"{board.BoardAbbreviation}-{ticketNumber}";
            }
            else
            {
                ticket.TicketId = Guid.NewGuid().ToId();
            }

            ticket.History.Add(new ServiceTicketStatusHistory()
            {
                AddedBy = template.PrimaryContact,
                DateStamp = DateTime.UtcNow.ToJSONString(),
                Status = ticket.Status.Text,
                Notes = $"Service ticket created and assigned to {assignedToUser.Text}."
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
            var template = await _repo.GetServiceTicketAsync(id);
            await AuthorizeAsync(template, AuthorizeResult.AuthorizeActions.Delete, user, org);
            await _repo.DeleteServiceTicketAsync(id);

            return InvokeResult.Success;
        }

        public async Task<ServiceTicket> GetServiceTicketAsync(string id, EntityHeader org, EntityHeader user)
        {
            var template = await _repo.GetServiceTicketAsync(id);
            await AuthorizeAsync(template, AuthorizeResult.AuthorizeActions.Delete, user, org);

            return template;
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
    }
}
