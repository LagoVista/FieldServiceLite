using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin.Interfaces
{
    public interface ITemplateCategoryManager
    {
        Task<InvokeResult> AddTemplateCategoryAsync(TemplateCategory templateCategory, EntityHeader org, EntityHeader user);
        Task<InvokeResult> UpdateTemplateCategoryAsync(TemplateCategory templateCategory, EntityHeader org, EntityHeader user);
        Task<InvokeResult> DeleteTemplateCateogryAsync(string id, EntityHeader org, EntityHeader user);
        Task<TemplateCategory> GetTemplateCategoryAsync(string id, EntityHeader org, EntityHeader user);
        Task<ListResponse<TemplateCategorySummary>> GetTemplateCategoriesAsync(ListRequest listRequest, EntityHeader org, EntityHeader user);

        Task<DependentObjectCheckResult> CheckInUseAsync(string id, EntityHeader org, EntityHeader user);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
    }
}
