using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin.Interfaces
{
    public interface ITicketStatusManager
    {
        Task<InvokeResult> AddTicketStatusItemsAsync(TicketStatusItems ticketStatusItems, EntityHeader org, EntityHeader user);
        Task<InvokeResult> UpdateTicketStatusItemsAsync(TicketStatusItems ticketStatusItems, EntityHeader org, EntityHeader user);
        Task<InvokeResult> DeleteTicketStatusItemsAsync(string id, EntityHeader org, EntityHeader user);
        Task<TicketStatusItems> GetTicketStatusItemsAsync(string id, EntityHeader org, EntityHeader user);
        Task<ListResponse<TicketStatusItemsSummary>> GetTicketStatusItemsAsync(ListRequest listRequest, EntityHeader org, EntityHeader user);
        Task<DependentObjectCheckResult> CheckInUseAsync(string id, EntityHeader org, EntityHeader user);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
    }
}
