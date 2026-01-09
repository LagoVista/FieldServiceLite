// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: b5ff009b0e04a8092d50ebb87bfbd58ce0eeaa992a2ab3f8a207fd5f97944591
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.CloudStorage;
using LagoVista.CloudStorage.DocumentDB;
using LagoVista.CloudStorage.Interfaces;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Admin.Interfaces;
using LagoVista.FSLite.Models;
using LagoVista.IoT.Logging.Loggers;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LagoVista.FSLite.CloudRepos
{
    public class TemplateCategoryRepo : DocumentDBRepoBase<TemplateCategory>, ITemplateCategoryRepo
    {
        private bool _shouldConsolidateCollections;
        public TemplateCategoryRepo(IFieldServiceLiteRepoSettings repoSettings, IDocumentCloudCachedServices services)
            : base(repoSettings.FieldServiceLiteDocDbStorage.Uri, repoSettings.FieldServiceLiteDocDbStorage.AccessKey, repoSettings.FieldServiceLiteDocDbStorage.ResourceName, services)
        {
            _shouldConsolidateCollections = repoSettings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections => _shouldConsolidateCollections;

        public Task AddTemplateCateogrydAsync(TemplateCategory board)
        {
            return CreateDocumentAsync(board);
        }

        public Task DeleteTemplateCateogryAsync(string id)
        {
            return DeleteDocumentAsync(id);
        }

        public async Task<ListResponse<TemplateCategorySummary>> GetTemplateCategoriesForOrgAsync(string orgId, ListRequest listRequest)
        {
            var response = await base.QueryAsync(attr => (attr.OwnerOrganization.Id == orgId || attr.IsPublic == true), listRequest);
            //TODO: This is a broken pattern to be fixed another day...sorry.
            var finalResponse = ListResponse<TemplateCategorySummary>.Create(response.Model.Select(mod => mod.CreateSummary()));
            finalResponse.NextPartitionKey = response.NextPartitionKey;
            finalResponse.NextRowKey = response.NextRowKey;
            finalResponse.PageCount = response.PageCount;
            finalResponse.PageCount = response.PageIndex;
            finalResponse.PageSize = response.PageSize;
            finalResponse.ResultId = response.ResultId;
            return finalResponse;
        }

        public Task<TemplateCategory> GetTemplateCategoryAsync(string id)
        {
            return GetDocumentAsync(id);
        }

        public async Task<bool> QueryKeyInUseAsync(string key, string orgId)
        {
            var items = await base.QueryAsync(attr => (attr.OwnerOrganization.Id == orgId || attr.IsPublic == true) && attr.Key == key);
            return items.Any();
        }

        public Task UpdateTemplateCateogryAsync(TemplateCategory board)
        {
            return this.UpsertDocumentAsync(board);
        }
    }
}
