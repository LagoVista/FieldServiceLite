using LagoVista.Core.Interfaces;
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
        }
    }
}
