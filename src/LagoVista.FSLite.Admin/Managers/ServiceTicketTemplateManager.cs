using LagoVista.Core.Interfaces;
using LagoVista.Core.Managers;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Admin.Interfaces;
using LagoVista.FSLite.Models;
using LagoVista.IoT.Logging.Loggers;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin.Managers
{
    public class ServiceTicketTemplateManager : ManagerBase, IServiceTicketTemplateManager {
        IServiceTicketTemplateRepo _repo;
        ISecureStorage _secureStorage;

        public ServiceTicketTemplateManager(IServiceTicketTemplateRepo repo, IAppConfig appConfig, IAdminLogger logger, ISecureStorage secureStorage,
            IDependencyManager depmanager, ISecurity security) : base(logger, appConfig, depmanager, security)
        {
            _repo = repo;
            _secureStorage = secureStorage;
        }

        public async Task<InvokeResult> AddServiceTicketTemplateAsync(ServiceTicketTemplate serviceTicketTemplate, EntityHeader org, EntityHeader user)
        {
            ValidationCheck(serviceTicketTemplate, Actions.Create);

            await AuthorizeAsync(serviceTicketTemplate, AuthorizeResult.AuthorizeActions.Create, user, org);
            await _repo.AddServiceTicketTemplateAsync(serviceTicketTemplate);

            return InvokeResult.Success;
        }

        public async Task<InvokeResult> DeleteServiceTicketTemplateAsync(string id, EntityHeader org, EntityHeader user)
        {
            var template = await _repo.GetServiceTicketTemplateAsync(id);

            await AuthorizeAsync(template, AuthorizeResult.AuthorizeActions.Delete, user, org);
            await _repo.DeleteServiceTicketTemplateAsync(id);

            return InvokeResult.Success;
        }

        public async Task<ServiceTicketTemplate> GetServiceTicketTemplateAsync(string id, EntityHeader org, EntityHeader user)
        {
            var template = await _repo.GetServiceTicketTemplateAsync(id);
            await AuthorizeAsync(template, AuthorizeResult.AuthorizeActions.Delete, user, org);

            return template;
        }

        public async Task<ListResponse<ServiceTicketTemplateSummary>> GetServiceTicketTemplatesAsync(ListRequest listRequest, EntityHeader org, EntityHeader user)
        {
            await AuthorizeOrgAccessAsync(user, org, typeof(ServiceTicketTemplate));
            return await _repo.GetServiceTicketTemplateSummariesForOrgAsync(org.Id, listRequest);
        }

        public async Task<InvokeResult> UpdateServiceTicketTemplateAsync(ServiceTicketTemplate serviceTicketTemplate, EntityHeader org, EntityHeader user)
        {
            await AuthorizeAsync(serviceTicketTemplate, AuthorizeResult.AuthorizeActions.Update, user, org);

            var result = Validator.Validate(serviceTicketTemplate, Actions.Update);

            await _repo.UpdateServiceTicketTemplateAsync(serviceTicketTemplate);

            return InvokeResult.Success;
        }
    }
}
