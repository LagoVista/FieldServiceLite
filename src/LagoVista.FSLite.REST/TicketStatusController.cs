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
using LagoVista.Core;
using System;
using System.Threading.Tasks;

namespace LagoVista.FSLite.REST
{
    [Authorize]
    public class TicketStatusController : LagoVistaBaseController
    {
        readonly ITicketStatusManager _mgr;

        public TicketStatusController(ITicketStatusManager ticketStatusMgr, UserManager<AppUser> userManager, IAdminLogger logger)
            : base(userManager, logger)
        {
            this._mgr = ticketStatusMgr;
        }

        /// <summary>
        /// FS Lite - Add a ticket status item.
        /// </summary>
        /// <param name="ticketstatusdefinition"></param>
        /// <returns></returns>
        [HttpPost("/api/fslite/ticketstatusdefinition")]
        public Task<InvokeResult> AddticketstatusdefinitionAsync([FromBody] TicketStatusDefinition ticketstatusdefinition)
        {
            return _mgr.AddTicketStatusDefinitionAsync(ticketstatusdefinition, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Update the ticket status items.
        /// </summary>
        /// <param name="ticketstatusdefinition"></param>
        /// <returns></returns>
        [HttpPut("/api/fslite/ticketstatusdefinition")]
        public Task<InvokeResult> UpdateticketstatusdefinitionAsync([FromBody] TicketStatusDefinition ticketstatusdefinition)
        {
            return _mgr.UpdateTicketStatusDefinitionAsync(ticketstatusdefinition, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Delete the ticket status items by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/api/fslite/ticketstatusdefinition/{id}")]
        public Task<InvokeResult> DeleteticketstatusdefinitionAsync(string id)
        {
            return _mgr.DeleteTicketStatusDefinitionAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite -  Get ticket status items by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/fslite/ticketstatusdefinition/{id}")]
        public async Task<DetailResponse<TicketStatusDefinition>> GetticketstatusdefinitionAsync(string id)
        {
            return DetailResponse<TicketStatusDefinition>.Create(await _mgr.GetTicketStatusDefinitionAsync(id, OrgEntityHeader, UserEntityHeader));
        }

        /// <summary>
        /// FS Lite - Get ticket status items detail by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/fslite/ticketstatusdefinition/{id}/detail")]
        public Task<TicketStatusDefinition> GetticketstatusdefinitionDetailAsync(string id)
        {
            return _mgr.GetTicketStatusDefinitionAsync(id, OrgEntityHeader, UserEntityHeader);
        }


        /// <summary>
        /// FS Lite - Create an empty ticket status items.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/fslite/ticketstatusdefinition/factory")]
        public DetailResponse<TicketStatusDefinition> Createticketstatusdefinition()
        {
            var status = DetailResponse<TicketStatusDefinition>.Create();
            status.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(status.Model);
            SetOwnedProperties(status.Model);
            return status;
        }

        /// <summary>
        /// FS Lite - Create an empty ticket status items.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/fslite/ticketstatusdefinition/item/factory")]
        public DetailResponse<TicketStatus> Createticketstatusitem()
        {
            var status = DetailResponse<TicketStatus>.Create();
            status.Model.Id = Guid.NewGuid().ToId();
            return status;
        }


        /// <summary>
        /// FS Lite - Get the ticket status items for an organization.
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/fslite/ticketstatusdefinition")]
        public Task<ListResponse<TicketStatusDefinitionSummary>> GetticketstatusdefinitionAsync()
        {
            return _mgr.GetTicketStatusDefinitionForOrgsAsync(GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Are the ticket status items in use
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/fslite/ticketstatusdefinition/{key}/keyinuse")]
        public Task<bool> GetticketstatusdefinitionKeyInUseAsync(String key)
        {
            return _mgr.QueryKeyInUseAsync(key, CurrentOrgId);
        }
    }
}
