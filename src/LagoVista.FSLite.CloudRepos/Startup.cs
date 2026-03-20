// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 87eeb0ebb7fc2065d7db24eab5c9106a9f2b603a0d417d312a06a5f7858345f1
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Interfaces;
using LagoVista.FSLite.Models;
using LagoVista.IoT.DeviceMessaging.Admin.Models;
using LagoVista.IoT.Logging.Loggers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Resources;

[assembly: NeutralResourcesLanguage("en")]
namespace LagoVista.FSLite.CloudRepos
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<Admin.Interfaces.IServiceTicketTemplateRepo, ServiceTicketTemplateRepo>();
            services.AddTransient<Admin.Interfaces.IServiceTicketRepo, ServiceTicketRepo>();
            services.AddTransient<Admin.Interfaces.IServiceBoardRepo, ServiceBoardRepo>();
            services.AddTransient<Admin.Interfaces.ITemplateCategoryRepo, TemplateCategoryRepo>();
            services.AddTransient<Admin.Interfaces.IPartsKitRepo, PartsKitRepo>();
            services.AddTransient<Admin.Interfaces.ITicketStatusRepo, TicketStatusRepo>();
        }
    }
}


namespace LagoVista.DependencyInjection
{
    public static class FsLiteModule
    {
        public static void AddFsLiteModule(this IServiceCollection services, IConfigurationRoot configRoot, IAdminLogger logger)
        {
            LagoVista.FSLite.CloudRepos.Startup.ConfigureServices(services);
            LagoVista.FSLite.Admin.Startup.ConfigureServices(services);
            services.AddMetaDataHelper<ServiceBoard>();
        }
    }
}