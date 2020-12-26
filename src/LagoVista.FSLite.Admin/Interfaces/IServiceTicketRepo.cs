﻿using LagoVista.Core.Models.UIMetaData;
using LagoVista.FSLite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin.Interfaces
{
    public interface IServiceTicketRepo
    {
        Task AddServiceTicketAsync(ServiceTicket ticket);
        Task UpdateServiceTicketAsync(ServiceTicket ticket);
        Task<ServiceTicket> GetServiceTicketAsync(string id);
        Task DeleteServiceTicketAsync(string id);

        Task<bool> HasOpenTicketOnDeviceAsync(string deviceId, string templateId, string orgId);
        Task<IEnumerable<ServiceTicket>> GetOpenTicketOnDeviceAsync(string deviceId, string templateId, string orgId);

        Task<ListResponse<ServiceTicketSummary>> GetTicketsForBoardAsync(string boardId, ListRequest listRequest);
        Task<ListResponse<ServiceTicketSummary>> GetTicketsForOrgAsync(string orgId, ListRequest listRequest);
        Task<ListResponse<ServiceTicketSummary>> GetTicketForDeviceAsync(string deviceId, string orgId, ListRequest listRequest);
        Task<ListResponse<ServiceTicketSummary>> GetTicketsWithStatusAsync(string statusId, string orgId, ListRequest listRequest);
        Task<ListResponse<ServiceTicketSummary>> GetOpenTicketsAsyncAsync(string orgId, ListRequest listRequest);
        Task<List<ServiceTicketSummary>> FindTicketsForNotificationRemindersAsync();
        Task<ListResponse<ServiceTicketSummary>> GetClosedTicketsAsyncAsync(string orgId, ListRequest listRequest);
        Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsByUserAsync(string userId, string orgId, ListRequest listRequest);
        Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsByTemplateAsync(string userId, string orgId, ListRequest listRequest);
        Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsAsync(TicketFilter filter, string orgId, ListRequest listRequest);
    }
}
