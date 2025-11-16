// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 65a3ed43105a3860d5667345be5c21b55dd9fe7e3c93ba40ed335231ac203939
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.CloudStorage;
using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.Interfaces;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.FSLite.Admin.Interfaces;
using LagoVista.FSLite.Models;
using LagoVista.IoT.Logging.Loggers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LagoVista.FSLite.CloudRepos
{
    public class PartsKitRepo : DocumentDBRepoBase<PartsKit>, IPartsKitRepo
    {
        private bool _shouldConsolidateCollections;
        public PartsKitRepo(IFieldServiceLiteRepoSettings repoSettings, IAdminLogger logger, ICacheProvider cacheProvider, IDependencyManager dependencyManager)
            : base(repoSettings.FieldServiceLiteDocDbStorage.Uri, repoSettings.FieldServiceLiteDocDbStorage.AccessKey, repoSettings.FieldServiceLiteDocDbStorage.ResourceName, logger, cacheProvider, dependencyManager)
        {
            _shouldConsolidateCollections = repoSettings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections => _shouldConsolidateCollections;


        public Task AddPartsKitAsync(PartsKit partsKit)
        {
            return CreateDocumentAsync(partsKit);
        }

        public Task DeletePartsKitAsync(string id)
        {
            return DeleteDocumentAsync(id);
        }

        public Task<PartsKit> GetPartsKitAsync(string id)
        {
            return GetDocumentAsync(id);
        }

        public async Task<ListResponse<PartsKitSummary>> GetPartsKitsForOrgAsync(string orgId, ListRequest listRequest)
        {
            var response = await base.QueryAsync(attr => (attr.OwnerOrganization.Id == orgId || attr.IsPublic == true), listRequest);
            //TODO: This is a broken pattern to be fixed another day...sorry.
            var finalResponse = ListResponse<PartsKitSummary>.Create(response.Model.Select(mod => mod.CreateSummary()));
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

        public Task UpdatePartsKitAsync(PartsKit partsKit)
        {
            return UpsertDocumentAsync(partsKit);
        }
    }
}
