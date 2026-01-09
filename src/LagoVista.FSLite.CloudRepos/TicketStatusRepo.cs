// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 9d7842183ec19a3df18dccd6318fd5200ad00d09e8b5a1191ca4ec6ee136565e
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.FSLite.Admin.Interfaces;
using LagoVista.FSLite.Models;
using LagoVista.IoT.Logging.Loggers;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LagoVista.CloudStorage;
using LagoVista.Core.Interfaces;
using LagoVista.CloudStorage.Interfaces;

namespace LagoVista.FSLite.CloudRepos
{
    public class TicketStatusRepo : DocumentDBRepoBase<TicketStatusDefinition>, ITicketStatusRepo
    {
        private bool _shouldConsolidateCollections;
        public TicketStatusRepo(IFieldServiceLiteRepoSettings repoSettings, IDocumentCloudCachedServices services)
            : base(repoSettings.FieldServiceLiteDocDbStorage.Uri, repoSettings.FieldServiceLiteDocDbStorage.AccessKey, repoSettings.FieldServiceLiteDocDbStorage.ResourceName, services)
        {
            _shouldConsolidateCollections = repoSettings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections => _shouldConsolidateCollections;

        public Task AddTicketStatusItemsAsync(TicketStatusDefinition ticketStatusItems)
        {
            return CreateDocumentAsync(ticketStatusItems);
        }

        public Task DeleteTicketStatusItemsAsync(string id)
        {
            return DeleteDocumentAsync(id);
        }

        public async Task<ListResponse<TicketStatusDefinitionSummary>> GetTicketStatusForOrgAsync(string orgId, ListRequest listRequest)
        {
            var response = await base.QueryAsync(attr => (attr.OwnerOrganization.Id == orgId || attr.IsPublic == true), listRequest);
            //TODO: This is a broken pattern to be fixed another day...sorry.
            var finalResponse = ListResponse<TicketStatusDefinitionSummary>.Create(response.Model.Select(mod => mod.CreateSummary()));
            finalResponse.NextPartitionKey = response.NextPartitionKey;
            finalResponse.NextRowKey = response.NextRowKey;
            finalResponse.PageCount = response.PageCount;
            finalResponse.PageCount = response.PageIndex;
            finalResponse.PageSize = response.PageSize;
            finalResponse.ResultId = response.ResultId;
            return finalResponse;
        }

        public Task<TicketStatusDefinition> GetTicketStatusDefinitionAsync(string id)
        {
            return GetDocumentAsync(id);
        }

        public async Task<bool> QueryKeyInUseAsync(string key, string orgId)
        {
            var items = await base.QueryAsync(attr => (attr.OwnerOrganization.Id == orgId || attr.IsPublic == true) && attr.Key == key);
            return items.Any();
        }

        public Task UpdateTicketStatusItemsAsync(TicketStatusDefinition ticketStatusItems)
        {
            return UpsertDocumentAsync(ticketStatusItems);
        }
    }
}
