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
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.FSLite.REST
{
    [Authorize]
    public class TemplateCategoryController : LagoVistaBaseController
    {
        ITemplateCategoryManager _mgr;

        public TemplateCategoryController(ITemplateCategoryManager mgr, UserManager<AppUser> userManager, IAdminLogger logger) 
            : base(userManager, logger)
        {
            _mgr = mgr;
        }

        /// <summary>
        /// FS Lite - Add a service board.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        [HttpPost("/api/fslite/templatecategory")]
        public Task<InvokeResult> AddServiceTicketTemplateAsync([FromBody] TemplateCategory category)
        {
            return _mgr.AddTemplateCategoryAsync(category, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Update the service board.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        [HttpPut("/api/fslite/templatecategory")]
        public Task<InvokeResult> UpdateServiceTicketTemplateAsync([FromBody] TemplateCategory category)
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
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/fslite/templatecategory/factory")]
        public DetailResponse<TemplateCategory> CreateServiceBoard(string id)
        {
            var board = DetailResponse<TemplateCategory>.Create();
            board.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(board.Model);
            SetOwnedProperties(board.Model);
            return board;
        }

        /// <summary>
        /// FS Lite - Get the template category.
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
        public Task<bool> GetServiceBoardKeyInUseAsync(String key)
        {
            return _mgr.QueryKeyInUseAsync(key, CurrentOrgId);
        }
    }
}
