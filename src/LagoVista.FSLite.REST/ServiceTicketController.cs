﻿using LagoVista.Core.Models;
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
using LagoVista.IoT.Deployment.Models;

namespace LagoVista.FSLite.REST
{
    [Authorize]
    public class ServiceTicketController : LagoVistaBaseController
    {

        readonly IServiceTicketManager _mgr;

        public ServiceTicketController(IServiceTicketManager mgr, UserManager<AppUser> userManager, IAdminLogger logger) : base(userManager, logger)
        {
            _mgr = mgr;
        }

        /// <summary>
        /// FS Lite - Add a ticket
        /// </summary>
        /// <param name="serviceTicket"></param>
        /// <returns></returns>
        [HttpPost("/api/fslite/ticket")]
        public Task<InvokeResult<string>> AddServiceTicketAsync([FromBody] ServiceTicket serviceTicket)
        {
            return _mgr.AddServiceTicketAsync(serviceTicket, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Update a ticket
        /// </summary>
        /// <param name="serviceTicket"></param>
        /// <returns></returns>
        [HttpPut("/api/fslite/ticket")]
        public Task<InvokeResult> UpdateServiceTicketAsync([FromBody] ServiceTicket serviceTicket)
        {
            return _mgr.UpdateServiceTicketAsync(serviceTicket, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Get a service ticket
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/fslite/ticket/{id}")]
        public async Task<DetailResponse<ServiceTicket>> GetServiceTicketAsync(string id)
        {
            return DetailResponse<ServiceTicket>.Create(await  _mgr.GetServiceTicketAsync(id, OrgEntityHeader, UserEntityHeader));
        }

        /// <summary>
        /// FS Lite -  Create a new service ticket template
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/fslite/ticket/factory")]
        public DetailResponse<ServiceTicket> CreateServiceTicketAsync()
        {
            var ticket = DetailResponse<ServiceTicket>.Create();
            SetAuditProperties(ticket.Model);
            SetOwnedProperties(ticket.Model);
            return ticket;

        }

        /// <summary>
        /// FS Lite - Get all open tickets
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/fslite/ticket/open")]
        public Task<ListResponse<ServiceTicketSummary>> GetOpenServiceTicketAsync()
        {
            return _mgr.GetOpenServiceTicketAsync(GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        [HttpPost("/api/fslite/ticket/create")]
        public Task<InvokeResult<string>> CreateTicket([FromBody] CreateServiceTicketRequest request)
        {
            return _mgr.CreateServiceTicketAsync(request, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - get closed tickets
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/fslite/ticket/closed")]
        public Task<ListResponse<ServiceTicketSummary>> GetClosedServiceTicketAsync()
        {
            return _mgr.GetClosedServiceTicketAsync(GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Get tickets for a device
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/fslite/ticket/device/{id}")]
        public Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsForDeviceAsync(string id)
        {
            return _mgr.GetServiceTicketsForDeviceAsync(id, GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Get tickets for org
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/fslite/tickets")]
        public Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsForOrgAsync()
        {
            return _mgr.GetServiceTicketsForOrgAsync(GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Get tickets for status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet("/api/fslite/tickets/status/{status}")]
        public Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsByStatusAsync(string status)
        {
            return _mgr.GetServiceTicketsByStatusAsync(status, GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Get Tickets for a Service Board
        /// </summary>
        /// <param name="boardid"></param>
        /// <returns></returns>
        [HttpGet("/api/fslite/{boardid}/tickets")]
        public Task<ListResponse<ServiceTicketSummary>> GetTicketsForBoard(string boardid)
        {
            return _mgr.GetTicketsForBoardAsync(boardid, GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Get closed tickets
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/fslite/tickets/close/{id}")]
        public Task<InvokeResult> CloseServiceTicketAsync(string id)
        {
            return _mgr.CloseServiceTicketAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Set View Status on a Ticket
        /// </summary>
        /// <param name="id"></param>
        /// <param name="viewed" />
        /// <returns></returns>
        [HttpGet("/api/fslite/ticket/{id}/viewed/{viewed}")]
        public Task<InvokeResult<ServiceTicket>> MarkAsViewedAsync(string id, bool viewed)
        {
            return _mgr.SetTicketViewedStatusAsync(id, viewed, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Set Closed Status on a Ticket
        /// </summary>
        /// <param name="id"></param>
        /// <param name="closed" />
        /// <returns></returns>
        [HttpGet("/api/fslite/ticket/{id}/closed/{closed}")]
        public Task<InvokeResult<ServiceTicket>> SetClosedStatusAsync(string id, bool closed)
        {
            return _mgr.SetTicketClosedStatusAsync(id, closed, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Delete service ticket
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/api/fslite/ticket/{id}")]
        public Task<InvokeResult> DeleteServiceTicketAsync(string id)
        {
            return _mgr.DeleteServiceTicketAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Assign a new user to ticket.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="assignedUser" />
        /// <returns></returns>
        [HttpPost("/api/fslite/ticket/{id}/assignedto")]
        public Task<InvokeResult<ServiceTicket>> AssignToUserAsync(string id, [FromBody] EntityHeader assignedUser)
        {
            return _mgr.SetAssignedToAsync(id, assignedUser, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Get a list of tickets with a filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost("/api/fslite/tickets")]
        public Task<ListResponse<ServiceTicketSummary>> GetFilteredtickets([FromBody] TicketFilter filter)
        {
            return _mgr.GetServiceTicketsAsync(filter, GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Create an empty note.
        /// </summary>
        /// <returns></returns>
        [HttpPost("/api/fslite/ticket/note/factory")]
        public DetailResponse<ServiceTicketNote> CreateTicketNote()
        {
            return DetailResponse<ServiceTicketNote>.Create();
        }

        /// <summary>
        /// FS Lite - Add a note to the service ticket.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        [HttpPost("/api/fslite/ticket/{id}/note")]
        public Task<InvokeResult<ServiceTicket>> AddTicketNoteAsync(string id, [FromBody] ServiceTicketNote note)
        {
            note.Id = Guid.NewGuid().ToId();
            note.AddedBy = UserEntityHeader;
            note.DateStamp = DateTime.UtcNow.ToJSONString();

            return _mgr.AddTicketNoteAsync(id, note, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Set Ticket Status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newStatus" />
        /// <returns></returns>
        [HttpPost("/api/fslite/ticket/{id}/status")]
        public Task<InvokeResult<ServiceTicket>> SetTicketStatusAsync(string id, [FromBody] EntityHeader newStatus)
        {
            return _mgr.SetTicketStatusAsync(id, newStatus, OrgEntityHeader, UserEntityHeader);
        }        
    }
}
