using LagoVista.Core.Models.UIMetaData;
using LagoVista.FSLite.Models;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin.Interfaces
{
    public interface IPartsKitRepo
    {
        Task AddPartsKitAsync(PartsKit partsKit);
        Task UpdatePartsKitAsync(PartsKit partsKit);
        Task DeletePartsKitAsync(string id);
        Task<PartsKit> GetPartsKitAsync(string id);
        Task<ListResponse<PartsKitSummary>> GetPartsKitsForOrgAsync(string orgId, ListRequest listRequest);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
    }
}
