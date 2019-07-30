using LagoVista.Core.Models.UIMetaData;
using LagoVista.FSLite.Models;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin.Interfaces
{
    public interface ITicketStatusRepo
    {
        Task AddTicketStatusItemsAsync(TicketStatusItems ticketStatusItems);
        Task UpdateTicketStatusItemsAsync(TicketStatusItems ticketStatusItems);
        Task DeleteTicketStatusItemsAsync(string id);
        Task<TicketStatusItems> GetTicketStatusItemsAsync(string id);
        Task<ListResponse<TicketStatusItemsSummary>> GetTicketStatusForOrgAsync(string orgId, ListRequest listRequest);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
    }
}
