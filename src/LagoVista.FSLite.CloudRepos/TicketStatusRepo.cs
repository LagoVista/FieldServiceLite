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

namespace LagoVista.FSLite.CloudRepos
{
    public class TicketStatusRepo : DocumentDBRepoBase<TicketStatusItems>, ITicketStatusRepo
    {
        private bool _shouldConsolidateCollections;
        public TicketStatusRepo(IFieldServiceLiteRepoSettings repoSettings, IAdminLogger logger)
            : base(repoSettings.FieldServiceLiteDocDbStorage.Uri, repoSettings.FieldServiceLiteDocDbStorage.AccessKey, repoSettings.FieldServiceLiteDocDbStorage.ResourceName, logger)
        {
            _shouldConsolidateCollections = repoSettings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections => _shouldConsolidateCollections;

        public Task AddTicketStatusItemsAsync(TicketStatusItems ticketStatusItems)
        {
            return CreateDocumentAsync(ticketStatusItems);
        }

        public Task DeleteTicketStatusItemsAsync(string id)
        {
            return DeleteDocumentAsync(id);
        }

        public async Task<ListResponse<TicketStatusItemsSummary>> GetTicketStatusForOrgAsync(string orgId, ListRequest listRequest)
        {
            var response = await base.QueryAsync(attr => (attr.OwnerOrganization.Id == orgId || attr.IsPublic == true), listRequest);
            //TODO: This is a broken pattern to be fixed another day...sorry.
            var finalResponse = ListResponse<TicketStatusItemsSummary>.Create(response.Model.Select(mod => mod.CreateSummary()));
            finalResponse.NextPartitionKey = response.NextPartitionKey;
            finalResponse.NextRowKey = response.NextRowKey;
            finalResponse.PageCount = response.PageCount;
            finalResponse.PageCount = response.PageIndex;
            finalResponse.PageSize = response.PageSize;
            finalResponse.ResultId = response.ResultId;
            return finalResponse;
        }

        public Task<TicketStatusItems> GetTicketStatusItemsAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> QueryKeyInUseAsync(string key, string orgId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTicketStatusItemsAsync(TicketStatusItems ticketStatusItems)
        {
            throw new NotImplementedException();
        }
    }
}
