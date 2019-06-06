using LagoVista.Core.Models.UIMetaData;
using LagoVista.FSLite.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin.Interfaces
{
    public interface IServiceTicketRepo
    {
        Task AddServiceTicketAsync(ServiceTicket ticket);
        Task UpdateServiceTicketAsync(ServiceTicket ticket);
        Task<ServiceTicket> GetServiceTicketAsync(string id);
        Task DeleteServiceTicketAsync(string id);

        Task<ListResponse<ServiceTicketSummary>> GetTicketsForOrgAsync(string orgId, ListRequest listRequest);
        Task<ListResponse<ServiceTicketSummary>> GetTicketForDeviceAsync(string deviceId, string orgId, ListRequest listRequest);
        Task<ListResponse<ServiceTicketSummary>> GetTicketsWithStatusAsync(string statusId, string orgId, ListRequest listRequest);
        Task<ListResponse<ServiceTicketSummary>> GetOpenTicketsAsyncAsync(string orgId, ListRequest listRequest);
        Task<ListResponse<ServiceTicketSummary>> GetClosedTicketsAsyncAsync(string orgId, ListRequest listRequest);
    }
}
