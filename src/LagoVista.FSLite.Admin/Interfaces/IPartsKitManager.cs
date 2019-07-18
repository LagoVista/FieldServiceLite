using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Models;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin.Interfaces
{
    public interface IPartsKitManager
    {
        Task<InvokeResult> AddPartsKitAsync(PartsKit partsKit, EntityHeader org, EntityHeader user);
        Task<InvokeResult> UpdatePartsKitAsync(PartsKit partsKit, EntityHeader org, EntityHeader user);
        Task<InvokeResult> DeletePartsKitAsync(string id, EntityHeader org, EntityHeader user);
        Task<PartsKit> GetPartsKitAsync(string id, EntityHeader org, EntityHeader user);
        Task<ListResponse<PartsKitSummary>> GetPartsKitsAsync(ListRequest listRequest, EntityHeader org, EntityHeader user);
        Task<DependentObjectCheckResult> CheckInUseAsync(string id, EntityHeader org, EntityHeader user);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
    }
}
