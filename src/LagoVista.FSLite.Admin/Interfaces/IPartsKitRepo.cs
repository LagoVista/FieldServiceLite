// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: fb3197b9fd093c8c4d517ea29ee01f5b436c2aa6462a19d0a4bf6621fb0a5286
// IndexVersion: 2
// --- END CODE INDEX META ---
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
