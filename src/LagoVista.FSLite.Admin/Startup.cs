
using LagoVista.Core.Interfaces;
using LagoVista.IoT.Deployment.Admin.Interfaces;
using System.Resources;

[assembly: NeutralResourcesLanguage("en")]


namespace LagoVista.FSLite.Admin
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<Interfaces.IServiceTicketManager, Managers.ServiceTicketManager>();
            services.AddTransient<IServiceTicketCreator, Managers.ServiceTicketManager>();
            services.AddTransient<Interfaces.IServiceTicketTemplateManager, Managers.ServiceTicketTemplateManager>();
            services.AddTransient<Interfaces.IServiceBoardManager, Managers.ServiceBoardManager>();
            services.AddTransient<Interfaces.ITemplateCategoryManager, Managers.TemplateCategoryManager>();
            services.AddTransient<Interfaces.IPartsKitManager, Managers.PartsKitManager>();
            services.AddTransient<Admin.Interfaces.ITicketStatusManager, TicketStatusManager>();
        }
    }
}
