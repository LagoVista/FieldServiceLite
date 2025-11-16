// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 5a2f47364e88e6535914d32707be8849bb9c4b7016da1a441aaa0d6c7a3f5f55
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Models.UIMetaData;
using LagoVista.FSLite.Models;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin.Interfaces
{
    public interface ITemplateCategoryRepo
    {
        Task AddTemplateCateogrydAsync(TemplateCategory board);
        Task UpdateTemplateCateogryAsync(TemplateCategory board);
        Task<TemplateCategory> GetTemplateCategoryAsync(string id);
        Task DeleteTemplateCateogryAsync(string id);
        Task<ListResponse<TemplateCategorySummary>> GetTemplateCategoriesForOrgAsync(string orgId, ListRequest listRequest);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
    }
}
