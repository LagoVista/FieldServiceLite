// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 87eeb0ebb7fc2065d7db24eab5c9106a9f2b603a0d417d312a06a5f7858345f1
// IndexVersion: 2
// --- END CODE INDEX META ---
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
            services.AddTransient<Admin.Interfaces.ITicketStatusRepo, TicketStatusRepo>();
        }
    }
}
