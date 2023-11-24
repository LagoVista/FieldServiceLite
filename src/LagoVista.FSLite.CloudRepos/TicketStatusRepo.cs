﻿using LagoVista.CloudStorage.DocumentDB;
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

namespace LagoVista.FSLite.CloudRepos
{
    public class TicketStatusRepo : DocumentDBRepoBase<TicketStatusDefinition>, ITicketStatusRepo
    {
        private bool _shouldConsolidateCollections;
        public TicketStatusRepo(IFieldServiceLiteRepoSettings repoSettings, IAdminLogger logger, ICacheProvider cacheProvider, IDependencyManager dependencyManager)
            : base(repoSettings.FieldServiceLiteDocDbStorage.Uri, repoSettings.FieldServiceLiteDocDbStorage.AccessKey, repoSettings.FieldServiceLiteDocDbStorage.ResourceName, logger, cacheProvider, dependencyManager)
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
