using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Admin.Interfaces;
using LagoVista.FSLite.Models;
using LagoVista.Core;   
using LagoVista.IoT.Logging.Loggers;
using LagoVista.IoT.Web.Common.Controllers;
using LagoVista.UserAdmin.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LagoVista.FSLite.REST
{
    [Authorize]
    public class PartsKitController : LagoVistaBaseController
    {
        IPartsKitManager _mgr;

        public PartsKitController(IPartsKitManager mgr, UserManager<AppUser> userManager, IAdminLogger logger)
            : base(userManager, logger)
        {
            _mgr = mgr;
        }

        /// <summary>
        /// FS Lite - Add a parts kit.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        [HttpPost("/api/fslite/partskit")]
        public Task<InvokeResult> AddPartsKitAsync([FromBody] PartsKit category)
        {
            return _mgr.AddPartsKitAsync(category, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Update the parts kit.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        [HttpPut("/api/fslite/partskit")]
        public Task<InvokeResult> UpdatePartsKitAsync([FromBody] PartsKit category)
        {
            return _mgr.UpdatePartsKitAsync(category, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Delete the parts kit.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/api/fslite/partskit/{id}")]
        public Task<InvokeResult> DeletePartsKitAsync(string id)
        {
            return _mgr.DeletePartsKitAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Get a parts kit by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/fslite/partskit/{id}")]
        public async Task<DetailResponse<PartsKit>> GetPartsKitAsync(string id)
        {
            return DetailResponse<PartsKit>.Create(await _mgr.GetPartsKitAsync(id, OrgEntityHeader, UserEntityHeader));
        }

        /// <summary>
        /// FS Lite - Get a parts detail kit by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/fslite/partskit/{id}/detail")]
        public Task<PartsKit> GetPartsKitDetailAsync(string id)
        {
            return _mgr.GetPartsKitAsync(id, OrgEntityHeader, UserEntityHeader);
        }


        /// <summary>
        /// FS Lite - Create the parts kit.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/fslite/partskit/factory")]
        public DetailResponse<PartsKit> CreatePartsKit(string id)
        {
            var board = DetailResponse<PartsKit>.Create();
            board.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(board.Model);
            SetOwnedProperties(board.Model);
            return board;
        }

        /// <summary>
        /// FS Lite - Get the parts kits for an organization.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/fslite/partskits")]
        public Task<ListResponse<PartsKitSummary>> GetPartsKitAsync()
        {
            return _mgr.GetPartsKitsAsync(GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Is the parts kit key in use
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/fslite/partskit/{key}/keyinuse")]
        public Task<bool> GetPartsKitKeyInUseAsync
            (String key)
        {
            return _mgr.QueryKeyInUseAsync(key, CurrentOrgId);
        }
    }
}
