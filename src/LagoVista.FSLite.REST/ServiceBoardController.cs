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
using System.Threading.Tasks;
using System;
using LagoVista.Core;
using System.IO;

namespace LagoVista.FSLite.REST
{
    [Authorize]
    public class ServiceBoardController : LagoVistaBaseController
    {
        IServiceBoardManager _mgr;

        public ServiceBoardController(IServiceBoardManager mgr, UserManager<AppUser> userManager, IAdminLogger logger) : base(userManager, logger)
        {
            _mgr = mgr;
        }

        /// <summary>
        /// FS Lite - Add a service board.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        [HttpPost("/api/fslite/serviceboard")]
        public Task<InvokeResult> AddServiceTicketTemplateAsync([FromBody] ServiceBoard board)
        {
            return _mgr.AddServiceBoardAsync(board, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Update a service board
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        [HttpPut("/api/fslite/serviceboard")]
        public Task<InvokeResult> UpdateServiceTicketTemplateAsync([FromBody] ServiceBoard board)
        {
            return _mgr.UpdateServiceBoardAsync(board, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Delete a service board.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/api/fslite/serviceboard/{id}")]
        public Task<InvokeResult> DeleteServiceTicketTemplateAsync(string id)
        {
            return _mgr.DeleteServiceBoardAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Get Service Board
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/fslite/serviceboard/{id}")]
        public async Task<DetailResponse<ServiceBoard>> GetServieBoardAsync(string id)
        {
            return DetailResponse<ServiceBoard>.Create(await _mgr.GetServiceBoardAsync(id, OrgEntityHeader, UserEntityHeader));
        }

        /// <summary>
        /// FS Lite - Create Service Board
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/fslite/serviceboard/factory")]
        public DetailResponse<ServiceBoard> CreateServiceBoard(string id)
        {
            var board = DetailResponse<ServiceBoard>.Create();
            board.Model.TicketSequenceNumber = 1;
            board.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(board.Model);
            SetOwnedProperties(board.Model);
            return board;
        }

        /// <summary>
        /// FS Lite - Get Service Board
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/fslite/serviceboards")]
        public Task<ListResponse<ServiceBoardSummary>> GetBoardSummaries()
        {
            return _mgr.GetServiceBoardsAsync(GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Is the service board in use.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/fslite/serviceboards/{key}/keyinuse")]
        public Task<bool> GetServiceBoardKeyInUseAsync(String key)
        {
            return _mgr.QueryKeyInUseAsync(key, CurrentOrgId);
        }
    }
}
