﻿using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.FSLite.Admin.Interfaces;
using LagoVista.FSLite.Models;
using LagoVista.IoT.Logging.Loggers;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.FSLite.CloudRepos
{
    public class TemplateCategoryRepo : DocumentDBRepoBase<TemplateCategory>, ITemplateCategoryRep
    {
        private bool _shouldConsolidateCollections;
        public TemplateCategoryRepo(IFieldServiceLiteRepoSettings repoSettings, IAdminLogger logger)
            : base(repoSettings.FieldServiceLiteDocDbStorage.Uri, repoSettings.FieldServiceLiteDocDbStorage.AccessKey,
                   repoSettings.FieldServiceLiteDocDbStorage.ResourceName, logger)
        {
            _shouldConsolidateCollections = repoSettings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections => _shouldConsolidateCollections;

        public Task AddTemplateCateogrydAsync(TemplateCategory board)
        {
            return this.CreateDocumentAsync(board);
        }

        public Task DeleteTemplateCateogryAsync(string id)
        {
            return this.DeleteDocumentAsync(id);
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
