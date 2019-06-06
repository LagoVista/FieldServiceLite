using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin.Interfaces
{
    public interface IServiceTicketManager
    {
        Task<InvokeResult> AddServiceTicketAsync(ServiceTicket serviceTicket, EntityHeader org, EntityHeader user);
        Task<InvokeResult> UpdateServiceTicketAsync(ServiceTicket serviceTicket, EntityHeader org, EntityHeader user);

        Task<ServiceTicket> GetServiceTicketAsync(string id, EntityHeader org, EntityHeader user);

        Task<ListResponse<ServiceTicketSummary>> GetOpenServiceTicketAsync(ListRequest listRequest, EntityHeader org, EntityHeader user);
        Task<ListResponse<ServiceTicketSummary>> GetClosedServiceTicketAsync(ListRequest listRequest, EntityHeader org, EntityHeader user);
        Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsForDeviceAsync(string deviceId, ListRequest listRequest, EntityHeader org, EntityHeader user);
        Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsForOrgAsync(ListRequest listRequest, EntityHeader org, EntityHeader user);
        Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsByStatusAsync(String statusId, ListRequest listRequest, EntityHeader org, EntityHeader user);


        Task<InvokeResult> CloseServiceTicketAsync(string id, EntityHeader org, EntityHeader user);
        Task<InvokeResult> DeleteServiceTicketAsync(string id, EntityHeader org, EntityHeader user);
    }
}
