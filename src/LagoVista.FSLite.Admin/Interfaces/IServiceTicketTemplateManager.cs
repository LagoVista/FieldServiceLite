// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 6862672f1dd86ef24670ae2cd6ccc851592375f83e434fed91bec1cc55bdb9ab
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Models;
using LagoVista.IoT.DeviceAdmin.Models;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin.Interfaces
{
    public interface IServiceTicketTemplateManager
    {
        Task<InvokeResult> AddServiceTicketTemplateAsync(ServiceTicketTemplate serviceTicket, EntityHeader org, EntityHeader user);
        Task<InvokeResult> UpdateServiceTicketTemplateAsync(ServiceTicketTemplate serviceTicket, EntityHeader org, EntityHeader user);
        Task<InvokeResult> DeleteServiceTicketTemplateAsync(string id, EntityHeader org, EntityHeader user);
        Task<ServiceTicketTemplate> GetServiceTicketTemplateAsync(string id, EntityHeader org, EntityHeader user);
        Task<ListResponse<ServiceTicketTemplateSummary>> GetServiceTicketTemplatesAsync(ListRequest listRequest, EntityHeader org, EntityHeader user);
        Task<DependentObjectCheckResult> CheckInUseAsync(string id, EntityHeader org, EntityHeader user);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
    }
}
