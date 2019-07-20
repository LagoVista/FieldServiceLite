using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.FSLite.Admin.Interfaces;
using LagoVista.FSLite.Models;
using LagoVista.IoT.Logging.Loggers;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.FSLite.CloudRepos
{
    public class ServiceTicketTemplateRepo : DocumentDBRepoBase<ServiceTicketTemplate>, IServiceTicketTemplateRepo
    {
        private bool _shouldConsolidateCollections;
        public ServiceTicketTemplateRepo(IFieldServiceLiteRepoSettings repoSettings, IAdminLogger logger)
            : base(repoSettings.FieldServiceLiteDocDbStorage.Uri, repoSettings.FieldServiceLiteDocDbStorage.AccessKey, repoSettings.FieldServiceLiteDocDbStorage.ResourceName, logger)
        {
            _shouldConsolidateCollections = repoSettings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections => _shouldConsolidateCollections;

        public Task AddServiceTicketTemplateAsync(ServiceTicketTemplate template)
        {
            if (!EntityHeader.IsNullOrEmpty(template.TemplateCategory))
            {
                template.TemplateCategory.Value = null;
            }

            return base.CreateDocumentAsync(template);
        }

        public Task DeleteServiceTicketTemplateAsync(string id)
        {
            return base.DeleteDocumentAsync(id);
        }

        public Task<ServiceTicketTemplate> GetServiceTicketTemplateAsync(string id)
        {
            return base.GetDocumentAsync(id);
        }

        public async Task<ListResponse<ServiceTicketTemplateSummary>> GetServiceTicketTemplateSummariesForOrgAsync(string orgId, ListRequest listRequest)
        {
            var response = await base.QueryAsync(attr => (attr.OwnerOrganization.Id == orgId || attr.IsPublic == true), listRequest);
            //TODO: This is a broken pattern to be fixed another day...sorry.
            var finalResponse = ListResponse<ServiceTicketTemplateSummary>.Create(response.Model.Select(mod => mod.CreateSummary()));
            finalResponse.NextPartitionKey = response.NextPartitionKey;
            finalResponse.NextRowKey = response.NextRowKey;
            finalResponse.PageCount = response.PageCount;
            finalResponse.PageCount = response.PageIndex;
            finalResponse.PageSize = response.PageSize;
            finalResponse.ResultId = response.ResultId;
            return finalResponse;
        }

        public async Task<bool> QueryKeyInUseAsync(string key, string orgId)
        {
            var items = await base.QueryAsync(attr => (attr.OwnerOrganization.Id == orgId || attr.IsPublic == true) && attr.Key == key);
            return items.Any();
        }

        public Task UpdateServiceTicketTemplateAsync(ServiceTicketTemplate template)
        {
            if (!EntityHeader.IsNullOrEmpty(template.TemplateCategory))
            {
                template.TemplateCategory.Value = null;
            }

            return base.UpsertDocumentAsync(template);
        }
    }
}
