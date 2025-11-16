// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 0e5fd790bc6396502ca74f4a923ee05782ee4f1eba99aee503b75e537568275b
// IndexVersion: 2
// --- END CODE INDEX META ---
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
