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

        Task<InvokeResult<string>> CreateServiceTicketAsync(string ticketTemplateId, string deviceRepoId, string deviceId);
        Task<InvokeResult<ServiceTicket>> CreateServiceTicketAsync(CreateServiceTicketRequest request, EntityHeader org, EntityHeader user);


        Task<ListResponse<ServiceTicketSummary>> GetTicketsForBoardAsync(string boardId, ListRequest listRequest, EntityHeader org, EntityHeader user);
        Task<ListResponse<ServiceTicketSummary>> GetOpenServiceTicketAsync(ListRequest listRequest, EntityHeader org, EntityHeader user);
        Task<ListResponse<ServiceTicketSummary>> GetClosedServiceTicketAsync(ListRequest listRequest, EntityHeader org, EntityHeader user);
        Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsForDeviceAsync(string deviceId, ListRequest listRequest, EntityHeader org, EntityHeader user);
        Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsForOrgAsync(ListRequest listRequest, EntityHeader org, EntityHeader user);
        Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsByStatusAsync(String statusKey, ListRequest listRequest, EntityHeader org, EntityHeader user);
        Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsByUserAsync(String userId, ListRequest listRequest, EntityHeader org, EntityHeader user);
        Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsByTemplateAsync(String templateId, ListRequest listRequest, EntityHeader org, EntityHeader user);
        Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsAsync(TicketFilter filter, ListRequest listRequest, EntityHeader org, EntityHeader user);

        Task<InvokeResult> CloseServiceTicketAsync(string id, EntityHeader org, EntityHeader user);
        Task<InvokeResult> DeleteServiceTicketAsync(string id, EntityHeader org, EntityHeader user);

        Task<InvokeResult> SetTicketStatusAsync(string id, EntityHeader newStatus, EntityHeader org, EntityHeader user);
        Task<InvokeResult> AddTicketNoteAsync(string id, ServiceTicketNote note, EntityHeader org, EntityHeader user);
    }
}
