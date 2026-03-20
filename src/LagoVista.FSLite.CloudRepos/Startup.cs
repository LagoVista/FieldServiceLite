using LagoVista.FSLite.Models;
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