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
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.FSLite.REST
{
    [Authorize]
    public class TicketStatusController : LagoVistaBaseController
    {
        ITicketStatusManager _mgr;

        public TicketStatusController(ITicketStatusManager ticketStatusMgr, UserManager<AppUser> userManager, IAdminLogger logger)
            : base(userManager, logger)
        {
            this._mgr = ticketStatusMgr;
        }

        /// <summary>
        /// FS Lite - Add a ticket status item.
        /// </summary>
        /// <param name="ticketStatusItems"></param>
        /// <returns></returns>
        [HttpPost("/api/fslite/ticketstatusitems")]
        public Task<InvokeResult> AddticketstatusitemsAsync([FromBody] TicketStatusItems ticketStatusItems)
        {
            return _mgr.AddTicketStatusItemsAsync(ticketStatusItems, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Update the ticket status items.
        /// </summary>
        /// <param name="ticketStatusItems"></param>
        /// <returns></returns>
        [HttpPut("/api/fslite/ticketstatusitems")]
        public Task<InvokeResult> UpdateticketstatusitemsAsync([FromBody] TicketStatusItems ticketStatusItems)
        {
            return _mgr.UpdateTicketStatusItemsAsync(ticketStatusItems, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Delete the ticket status items by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/api/fslite/ticketstatusitems/{id}")]
        public Task<InvokeResult> DeleteticketstatusitemsAsync(string id)
        {
            return _mgr.DeleteTicketStatusItemsAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite -  Get ticket status items by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/fslite/ticketstatusitems/{id}")]
        public async Task<DetailResponse<TicketStatusItems>> GetticketstatusitemsAsync(string id)
        {
            return DetailResponse<TicketStatusItems>.Create(await _mgr.GetTicketStatusItemsAsync(id, OrgEntityHeader, UserEntityHeader));
        }

        /// <summary>
        /// FS Lite - Get ticket status items detail by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/fslite/ticketstatusitems/{id}/detail")]
        public Task<TicketStatusItems> GetticketstatusitemsDetailAsync(string id)
        {
            return _mgr.GetTicketStatusItemsAsync(id, OrgEntityHeader, UserEntityHeader);
        }


        /// <summary>
        /// FS Lite - Create an empty ticket status items.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/fslite/ticketstatusitems/factory")]
        public DetailResponse<TicketStatusItems> CreateticketStatusItems(string id)
        {
            var status = DetailResponse<TicketStatusItems>.Create();
            status.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(status.Model);
            SetOwnedProperties(status.Model);
            return status;
        }

        /// <summary>
        /// FS Lite - Create an empty ticket status items.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/fslite/ticketstatusitems/item/factory")]
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
        [HttpGet("/api/fslite/ticketstatusitemss")]
        public Task<ListResponse<TicketStatusItemsSummary>> GetticketstatusitemsAsync()
        {
            return _mgr.GetTicketStatusItemsAsync(GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Are the ticket status items in use
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/fslite/ticketstatusitems/{key}/keyinuse")]
        public Task<bool> GetticketstatusitemsKeyInUseAsync(String key)
        {
            return _mgr.QueryKeyInUseAsync(key, CurrentOrgId);
        }
    }
}
