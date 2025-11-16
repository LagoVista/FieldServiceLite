// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: d25d5d5161ccad641020eedb1c82bb8f041a0b3440309157df3af5f3d48928cc
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Models.UIMetaData;
using LagoVista.FSLite.Models;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin.Interfaces
{
    public interface IServiceTicketTemplateRepo
    {
        Task AddServiceTicketTemplateAsync(ServiceTicketTemplate serviceTicket);
        Task UpdateServiceTicketTemplateAsync(ServiceTicketTemplate serviceTicket);
        Task DeleteServiceTicketTemplateAsync(string id);
        Task<ServiceTicketTemplate> GetServiceTicketTemplateAsync(string id);
        Task<ServiceTicketTemplate> GetServiceTicketTemplateByKeyAsync(string orgId, string key);
        Task<ListResponse<ServiceTicketTemplateSummary>> GetServiceTicketTemplateSummariesForOrgAsync(string orgId, ListRequest listRequest);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
    }
}
