using LagoVista.Core.Models;
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
    public class ServiceTicketController : LagoVistaBaseController
    {

        IServiceTicketManager _mgr;

        public ServiceTicketController(IServiceTicketManager mgr, UserManager<AppUser> userManager, IAdminLogger logger) : base(userManager, logger)
        {
            _mgr = mgr;
        }

        /// <summary>
        /// FS Lite - Add a ticket
        /// </summary>
        /// <param name="serviceTicket"></param>
        /// <returns></returns>
        [HttpPost("/api/serviceticket")]
        public Task<InvokeResult> AddServiceTicketAsync([FromBody] ServiceTicket serviceTicket)
        {
            return _mgr.AddServiceTicketAsync(serviceTicket, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Update a ticket
        /// </summary>
        /// <param name="serviceTicket"></param>
        /// <returns></returns>
        [HttpPut("/api/serviceticket")]
        public Task<InvokeResult> UpdateServiceTicketAsync([FromBody] ServiceTicket serviceTicket)
        {
            return _mgr.UpdateServiceTicketAsync(serviceTicket, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Get a service ticket
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/serviceticket/{id}")]
        public async Task<DetailResponse<ServiceTicket>> GetServiceTicketAsync(string id)
        {
            return DetailResponse<ServiceTicket>.Create(await  _mgr.GetServiceTicketAsync(id, OrgEntityHeader, UserEntityHeader));
        }

        /// <summary>
        /// FS Lite -  Create a new service ticket template
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/serviceticket/factory")]
        public DetailResponse<ServiceTicket> CreateServiceTicketAsync()
        {
            var ticket = new ServiceTicket()
            {
                Id = Guid.NewGuid().ToId(),
            };

            SetAuditProperties(ticket);
            SetOwnedProperties(ticket);

            return DetailResponse<ServiceTicket>.Create(ticket);
        }

        /// <summary>
        /// FS Lite - Get all open tickets
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/servicetickets/open")]
        public Task<ListResponse<ServiceTicketSummary>> GetOpenServiceTicketAsync()
        {
            return _mgr.GetOpenServiceTicketAsync(GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - get closed tickets
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/servicetickets/closed")]
        public Task<ListResponse<ServiceTicketSummary>> GetClosedServiceTicketAsync()
        {
            return _mgr.GetClosedServiceTicketAsync(GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Get tickets for a device
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/servicetickets/device/{id}")]
        public Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsForDeviceAsync(string id)
        {
            return _mgr.GetOpenServiceTicketAsync(GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Get tickets for org
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/servicetickets")]
        public Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsForOrgAsync()
        {
            return _mgr.GetServiceTicketsForOrgAsync(GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Get tickets for status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet("/api/servicetickets/status/{status}")]
        public Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsByStatusAsync(string status)
        {
            return _mgr.GetServiceTicketsByStatusAsync(status, GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Get closed tickets
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/api/serviceticket/close/{id}")]
        public Task<InvokeResult> CloseServiceTicketAsync(string id)
        {
            return _mgr.CloseServiceTicketAsync(id, OrgEntityHeader, UserEntityHeader);
        }


        /// <summary>
        /// FS Lite - Delete service ticket
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/api/serviceticket/{id}")]
        public Task<InvokeResult> DeleteServiceTicketAsync(string id)
        {
            return _mgr.DeleteServiceTicketAsync(id, OrgEntityHeader, UserEntityHeader);
        }
    }
}
