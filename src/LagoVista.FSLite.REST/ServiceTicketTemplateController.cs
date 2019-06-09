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
    public class ServiceTicketTemplateController : LagoVistaBaseController
    {
        IServiceTicketTemplateManager _mgr;

        public ServiceTicketTemplateController(IServiceTicketTemplateManager mgr, UserManager<AppUser> userManager, IAdminLogger logger) : base(userManager, logger)
        {
            _mgr = mgr;
        }

        /// <summary>
        /// FS Lite - Add ticket template
        /// </summary>
        /// <param name="serviceTicket"></param>
        /// <returns></returns>
        [HttpPost("/api/fslite/tickets/template")]
        public Task<InvokeResult> AddServiceTicketTemplateAsync([FromBody] ServiceTicketTemplate serviceTicket)
        {
            return _mgr.AddServiceTicketTemplateAsync(serviceTicket, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - update ticket template
        /// </summary>
        /// <param name="serviceTicket"></param>
        /// <returns></returns>
        [HttpPut("/api/fslite/tickets/template")]
        public Task<InvokeResult> UpdateServiceTicketTemplateAsync([FromBody] ServiceTicketTemplate serviceTicket)
        {
            return _mgr.UpdateServiceTicketTemplateAsync(serviceTicket, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Delete Ticket Template
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("/api/fslite/tickets/template/{id}")]
        public Task<InvokeResult> DeleteServiceTicketTemplateAsync(string id)
        {
            return _mgr.DeleteServiceTicketTemplateAsync(id, OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Get Ticket Template
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/fslite/tickets/template/{id}")]
        public async Task<DetailResponse<ServiceTicketTemplate>> GetServiceTicketTemplateAsync(string id)
        {
            return DetailResponse<ServiceTicketTemplate>.Create(await _mgr.GetServiceTicketTemplateAsync(id, OrgEntityHeader, UserEntityHeader));
        }

        /// <summary>
        /// FS Lite - Create ticket template
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/api/fslite/tickets/template/factory")]
        public DetailResponse<ServiceTicketTemplate> CreateServiceTicketTemplateAsync(string id)
        {
            var template = DetailResponse<ServiceTicketTemplate>.Create();
            template.Model.Id = Guid.NewGuid().ToId();
            SetAuditProperties(template.Model);
            SetOwnedProperties(template.Model);
            return template;
        }

        /// <summary>
        /// FS Lite - Get Ticket Templates
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/fslite/tickets/templates")]
        public Task<ListResponse<ServiceTicketTemplateSummary>> GetServiceTicketTemplatesAsync()
        {
            return _mgr.GetServiceTicketTemplatesAsync(GetListRequestFromHeader(), OrgEntityHeader, UserEntityHeader);
        }

        /// <summary>
        /// FS Lite - Key In Use
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/fslite/tickets/templates/{key}/keyinuse")]
        public Task<bool> GetDeviceTypeKeyInUseAsync(String key)
        {
            return _mgr.QueryKeyInUseAsync(key, CurrentOrgId);
        }

        /// <summary>
        /// FS Lite - Get Required Parts Resource
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/fslite/template/{templateid}/troubleshooting/{partid}/media/{resourceid}")]
        public async Task<IActionResult> GetRequiredPartsResourceAsync(string templateid, string partid, string resourceid)
        {
            var response = await _mgr.GetPartMediaAsync(templateid, partid, resourceid, OrgEntityHeader, UserEntityHeader);
            var ms = new MemoryStream(response.ImageBytes);
            return new FileStreamResult(ms, response.ContentType);
        }

        /// <summary>
        /// FS Lite - Get Troubleshooting Steps Resource
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/fslite/template/{templateid}/troubleshooting/{tsid}/media/{resourceid}")]
        public async Task<IActionResult> GetTroubleshootingStepResourceAsync(string templateid, string tsid, string resourceid)
        {
            var response = await _mgr.GetTroubleshottingStepMediaAsync(templateid, tsid, resourceid, OrgEntityHeader, UserEntityHeader);

            var ms = new MemoryStream(response.ImageBytes);
            return new FileStreamResult(ms, response.ContentType);
        }
    }
}
