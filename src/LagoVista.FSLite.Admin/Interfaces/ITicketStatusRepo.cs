using LagoVista.Core.Models.UIMetaData;
using LagoVista.FSLite.Models;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin.Interfaces
{
    public interface ITicketStatusRepo
    {
        Task AddTicketStatusItemsAsync(TicketStatusDefinition ticketStatusItems);
        Task UpdateTicketStatusItemsAsync(TicketStatusDefinition ticketStatusItems);
        Task DeleteTicketStatusItemsAsync(string id);
        Task<TicketStatusDefinition> GetTicketStatusDefinitionAsync(string id);
        Task<ListResponse<TicketStatusDefinitionSummary>> GetTicketStatusForOrgAsync(string orgId, ListRequest listRequest);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
    }
}
