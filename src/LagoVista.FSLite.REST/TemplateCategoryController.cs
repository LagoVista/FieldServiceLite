// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: a74396a9983b348fefb98f61284dc61883f2c1cd2912d26e5ae5347887e1b940
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Admin.Interfaces;
using LagoVista.FSLite.Models;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.IoT.Web.Common.Controllers;
using LagoVista.UserAdmin.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using LagoVista.Core;
using System.Threading.Tasks;

namespace LagoVista.FSLite.REST
{
    [Authorize]
    public class TemplateCategoryController : LagoVistaBaseController
    {
        readonly ITemplateCategoryManager _mgr;

        public TemplateCategoryController(ITemplateCategoryManager mgr, UserManager<AppUser> userManager, IAdminLogger logger) 
            : base(userManager, logger)
        {
            _mgr = mgr;
        }

        /// <summary>
        /// FS Lite - Add a template category.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost("/api/fslite/templatecategory")]
        public Task<InvokeResult> AddTemplateCategoryAsync([FromBody] TemplateCategory category)
        {
            return _mgr.AddTemplateCategoryAsync(category, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Update a template category.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPut("/api/fslite/templatecategory")]
        public Task<InvokeResult> UpdateTemplateCategoriesAsync([FromBody] TemplateCategory category)
        {
            return _mgr.UpdateTemplateCategoryAsync(category, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Delete the template category.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/api/fslite/templatecategory/{id}")]
        public Task<InvokeResult> DeleteTemplateCategoryAsync(string id)
        {
            return _mgr.DeleteTemplateCateogryAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Get a template category by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/fslite/templatecategory/{id}")]
        public async Task<DetailResponse<TemplateCategory>> GetTemplateCategoryAsync(string id)
        {
            return DetailResponse<TemplateCategory>.Create(await _mgr.GetTemplateCategoryAsync(id, OrgEntityHeader, UserEntityHeader));
        }

        /// <summary>
        /// FS Lite - Create the template category.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/fslite/templatecategory/factory")]
        public DetailResponse<TemplateCategory> CreateTemplateCategory()
        {
            var board = DetailResponse<TemplateCategory>.Create();
            board.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(board.Model);
            SetOwnedProperties(board.Model);
            return board;
        }

        /// <summary>
        /// FS Lite - Get the template categories for an organization.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/fslite/templatecategories")]
        public Task<ListResponse<TemplateCategorySummary>> GetTemplateCategories()
        {
            return _mgr.GetTemplateCategoriesAsync(GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Is the template category in use.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/fslite/templatecategory/{key}/keyinuse")]
        public Task<bool> GetTemplateCategoryKeyInUseAsync(String key)
        {
            return _mgr.QueryKeyInUseAsync(key, CurrentOrgId);
        }
    }
}
