using LagoVista.Core.Exceptions;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Managers;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Admin.Interfaces;
using LagoVista.FSLite.Models;
using LagoVista.IoT.DeviceAdmin.Interfaces.Managers;
using LagoVista.IoT.DeviceAdmin.Models;
using LagoVista.IoT.Logging.Loggers;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin.Managers
{
    public class ServiceTicketTemplateManager : ManagerBase, IServiceTicketTemplateManager
    {
        IServiceTicketTemplateRepo _repo;
        ISecureStorage _secureStorage;
        IMediaResourceRepo _mediaRepo;

        public ServiceTicketTemplateManager(IServiceTicketTemplateRepo repo, IMediaResourceRepo mediaRepo, IAppConfig appConfig, IAdminLogger logger, ISecureStorage secureStorage,
            IDependencyManager depmanager, ISecurity security) : base(logger, appConfig, depmanager, security)
        {
            _repo = repo;
            _mediaRepo = mediaRepo;
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
            await ConfirmNoDepenenciesAsync(template);

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

        public async Task<MediaItemResponse> GetPartMediaAsync(string templateId, string partId, string resourceId, EntityHeader org, EntityHeader user)
        {
            var template = await _repo.GetServiceTicketTemplateAsync(templateId);
            if (template == null)
            {
                throw new RecordNotFoundException(nameof(ServiceTicketTemplate), templateId);
            }

            await AuthorizeOrgAccessAsync(user, org.Id, typeof(MediaResource));
           
            var requiredPart = template.RequiredParts.Where(dvc => dvc.Id == partId).FirstOrDefault();
            if (requiredPart == null)
            {
                throw new RecordNotFoundException(nameof(MediaResource), resourceId);
            }

            var resource = requiredPart.Resources.Where(dvc => dvc.Id == resourceId).FirstOrDefault();
            if (resource == null)
            {
                throw new RecordNotFoundException(nameof(MediaResource), resourceId);
            }

            var mediaItem = await _mediaRepo.GetMediaAsync(resource.FileName, org.Id);
            if (!mediaItem.Successful)
            {
                throw new RecordNotFoundException(nameof(MediaResource), resource.FileName);
            }

            return new MediaItemResponse()
            {
                ContentType = resource.MimeType,
                FileName = resource.FileName,
                ImageBytes = mediaItem.Result
            };
        }

        public async Task<MediaItemResponse> GetTroubleshottingStepMediaAsync(string templateId, string stepId, string resourceId, EntityHeader org, EntityHeader user)
        {
            var template = await _repo.GetServiceTicketTemplateAsync(templateId);
            if (template == null)
            {
                throw new RecordNotFoundException(nameof(ServiceTicketTemplate), templateId);
            }

            await AuthorizeOrgAccessAsync(user, org.Id, typeof(MediaResource));

            var troubleshootingStep = template.TroubleshootingSteps.Where(dvc => dvc.Id == stepId).FirstOrDefault();
            if (troubleshootingStep == null)
            {
                throw new RecordNotFoundException(nameof(TroubleshootingStep), stepId);
            }

            var resource = troubleshootingStep.Resources.Where(dvc => dvc.Id == resourceId).FirstOrDefault();
            if (resource == null)
            {
                throw new RecordNotFoundException(nameof(MediaResource), resourceId);
            }

            var mediaItem = await _mediaRepo.GetMediaAsync(resource.FileName, org.Id);
            if (!mediaItem.Successful)
            {
                throw new RecordNotFoundException(nameof(MediaResource), resource.FileName);
            }

            return new MediaItemResponse()
            {
                ContentType = resource.MimeType,
                FileName = resource.FileName,
                ImageBytes = mediaItem.Result
            };
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
