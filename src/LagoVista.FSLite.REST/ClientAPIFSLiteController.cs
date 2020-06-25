using LagoVista.FSLite.Admin.Interfaces;
using LagoVista.IoT.Logging.Loggers;
using LagoVista.IoT.Web.Common.Controllers;
using LagoVista.UserAdmin.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LagoVista.FSLite.REST
{
    [Authorize(AuthenticationSchemes = "APIToken")]
    public class ClientAPIFSLiteController : LagoVistaBaseController
    {
        IServiceTicketManager _fsLiteManager;

        public ClientAPIFSLiteController(IServiceTicketManager fsLiteManager, UserManager<AppUser> userManager, IAdminLogger logger)
            : base(userManager, logger)
        {
            _fsLiteManager = fsLiteManager;
        }

        [HttpGet("/clientapi/fslite/sendreminders")]
        public Task SendRemindersAsync()
        {
            return _fsLiteManager.SendTicketRemindersAsync();
        }
    }
}
