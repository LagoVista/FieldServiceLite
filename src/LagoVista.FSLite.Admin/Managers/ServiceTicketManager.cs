using LagoVista.Core.Interfaces;
using LagoVista.Core.Managers;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Admin.Interfaces;
using LagoVista.FSLite.Models;
using LagoVista.IoT.Logging.Loggers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin.Managers
{
    public class ServiceTicketManager : ManagerBase, IServiceTicketManager
    {
        IServiceTicketRepo _repo;
        ISecureStorage _secureStorage;

        public ServiceTicketManager(IServiceTicketRepo repo, IAppConfig appConfig, IAdminLogger logger, ISecureStorage secureStorage,
            IDependencyManager depmanager, ISecurity security) : base(logger, appConfig, depmanager, security)
        {
            _repo = repo;
            _secureStorage = secureStorage;
        }

        public async Task<InvokeResult> AddServiceTicketAsync(ServiceTicket serviceTicket, EntityHeader org, EntityHeader user)
        {
            ValidationCheck(serviceTicket, Actions.Create);

            await AuthorizeAsync(serviceTicket, AuthorizeResult.AuthorizeActions.Create, user, org);
            await _repo.AddServiceTicketAsync(serviceTicket);

            return InvokeResult.Success;
        }

        public async Task<InvokeResult> CloseServiceTicketAsync(string id, EntityHeader org, EntityHeader user)
        {
            var serviceTicket = await _repo.GetServiceTicketAsync(id);

            await AuthorizeAsync(serviceTicket, AuthorizeResult.AuthorizeActions.Create, user, org);

            if(serviceTicket.IsClosed)
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
    }
}
