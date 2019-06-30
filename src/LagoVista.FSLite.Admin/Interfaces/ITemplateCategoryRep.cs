using LagoVista.Core.Models.UIMetaData;
using LagoVista.FSLite.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin.Interfaces
{
    public interface ITemplateCategoryRep
    {
        Task AddTemplateCateogrydAsync(TemplateCategory board);
        Task UpdateTemplateCateogryAsync(TemplateCategory board);
        Task<TemplateCategory> GetTemplateCategoryAsync(string id);
        Task DeleteTemplateCateogryAsync(string id);
        Task<ListResponse<TemplateCategorySummary>> GetTemplateCategoriesForOrgAsync(string orgId, ListRequest listRequest);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
    }
}
