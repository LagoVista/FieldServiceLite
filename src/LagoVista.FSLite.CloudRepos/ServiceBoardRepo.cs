using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.FSLite.Admin.Interfaces;
using LagoVista.FSLite.Models;
using LagoVista.IoT.Logging.Loggers;
using System.Linq;
using System;
using LagoVista.Core;
using System.Threading.Tasks;

namespace LagoVista.FSLite.CloudRepos
{
    public class ServiceBoardRepo : DocumentDBRepoBase<ServiceBoard>, IServiceBoardRepo
    {
        private bool _shouldConsolidateCollections;
        public ServiceBoardRepo(IFieldServiceLiteRepoSettings repoSettings, IAdminLogger logger)
            : base(repoSettings.FieldServiceLiteDocDbStorage.Uri, repoSettings.FieldServiceLiteDocDbStorage.AccessKey, repoSettings.FieldServiceLiteDocDbStorage.ResourceName, logger)
        {
            _shouldConsolidateCollections = repoSettings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections => _shouldConsolidateCollections;

        public Task AddServiceBoardAsync(ServiceBoard board)
        {
            return CreateDocumentAsync(board);
        }

        public Task DeleteServiceBoardAsync(string id)
        {
            return DeleteDocumentAsync(id);
        }

        public Task<ServiceBoard> GetServiceBoardAsync(string id)
        {
            return GetDocumentAsync(id);
        }

        public async Task<int> GetNextTicketNumber(string id)
        {
            var board = await GetServiceBoardAsync(id);
            board.TicketSequenceNumber++;
            board.LastUpdatedDate = DateTime.UtcNow.ToJSONString();
            await UpdateServiceBoardAsync(board);
            return board.TicketSequenceNumber;
        }

        public async Task<ListResponse<ServiceBoardSummary>> GetServiceBoardForOrgAsync(string orgId, ListRequest listRequest)
        {
            var response = await base.QueryAsync(attr => (attr.OwnerOrganization.Id == orgId || attr.IsPublic == true), listRequest);
            //TODO: This is a broken pattern to be fixed another day...sorry.
            var finalResponse = ListResponse<ServiceBoardSummary>.Create(response.Model.Select(mod => mod.CreateSummary()));
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

        public Task UpdateServiceBoardAsync(ServiceBoard board)
        {
            return UpsertDocumentAsync(board);
        }
    }
}
