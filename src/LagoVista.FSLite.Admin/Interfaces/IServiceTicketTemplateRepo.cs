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
