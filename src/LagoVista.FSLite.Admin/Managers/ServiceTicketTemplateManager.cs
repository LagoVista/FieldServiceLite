// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: d6a54ae6810f48f826c24e7d63afd1800a1377a9328fa1a38fc0d62a66cd4730
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Exceptions;
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
    public class ServiceTicketTemplateManager : ManagerBase, IServiceTicketTemplateManager
    {
        IServiceTicketTemplateRepo _repo;
        ISecureStorage _secureStorage;
        ITemplateCategoryRepo _templateCategoryRepo;

        public ServiceTicketTemplateManager(IServiceTicketTemplateRepo repo, ITemplateCategoryRepo templateCategoryRepo, IAppConfig appConfig, IAdminLogger logger, ISecureStorage secureStorage,
            IDependencyManager depmanager, ISecurity security) : base(logger, appConfig, depmanager, security)
        {
            _repo = repo;
            _secureStorage = secureStorage;
            _templateCategoryRepo = templateCategoryRepo;
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
            await ConfirmNoDepenenciesAsync(template);

            await AuthorizeAsync(template, AuthorizeResult.AuthorizeActions.Delete, user, org);
            await _repo.DeleteServiceTicketTemplateAsync(id);

            return InvokeResult.Success;
        }

        public async Task<ServiceTicketTemplate> GetServiceTicketTemplateAsync(string id, EntityHeader org, EntityHeader user)
        {
            var template = await _repo.GetServiceTicketTemplateAsync(id);
            if(!EntityHeader.IsNullOrEmpty(template.TemplateCategory))
            {
                template.TemplateCategory.Value = await _templateCategoryRepo.GetTemplateCategoryAsync(template.TemplateCategory.Id);
            }

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

        public Task<bool> QueryKeyInUseAsync(string key, string orgId)
        {
            return _repo.QueryKeyInUseAsync(key, orgId);
        }

        public async Task<DependentObjectCheckResult> CheckInUseAsync(string id, EntityHeader org, EntityHeader user)
        {
            var template = await _repo.GetServiceTicketTemplateAsync(id);
            await AuthorizeAsync(template, AuthorizeResult.AuthorizeActions.Read, user, org);
            return await CheckForDepenenciesAsync(template);
        }
    }
}
