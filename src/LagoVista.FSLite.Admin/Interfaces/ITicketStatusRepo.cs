// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 43ec6cf45db9d0f85ad5261a9371028d1e4e2ac4cc52fa9945fefa4ecc8fef1f
// IndexVersion: 2
// --- END CODE INDEX META ---
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
