using LagoVista.CloudStorage.DocumentDB;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.FSLite.Admin.Interfaces;
using LagoVista.FSLite.Models;
using LagoVista.IoT.Logging.Loggers;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LagoVista.FSLite.CloudRepos
{
    public class ServiceTicketRepo : DocumentDBRepoBase<ServiceTicket>, IServiceTicketRepo
    {
        private bool _shouldConsolidateCollections;
        public ServiceTicketRepo(IFieldServiceLiteRepoSettings repoSettings, IAdminLogger logger)
            : base(repoSettings.FieldServiceLiteDocDbStorage.Uri, repoSettings.FieldServiceLiteDocDbStorage.AccessKey, repoSettings.FieldServiceLiteDocDbStorage.ResourceName, logger)
        {
            _shouldConsolidateCollections = repoSettings.ShouldConsolidateCollections;
        }

        protected override bool ShouldConsolidateCollections => _shouldConsolidateCollections;

        public Task AddServiceTicketAsync(ServiceTicket ticket)
        {
            return CreateDocumentAsync(ticket);
        }

        public Task DeleteServiceTicketAsync(string id)
        {
            return DeleteDocumentAsync(id);
        }

        private async Task<ListResponse<ServiceTicketSummary>> GetServiceTickets(Expression<Func<ServiceTicket, bool>> func, ListRequest listRequest)
        {
            var response = await base.QueryAsync(func, listRequest);
            //TODO: This is a broken pattern to be fixed another day...sorry.
            var finalResponse = ListResponse<ServiceTicketSummary>.Create(response.Model.Select(mod => mod.CreateSummary()));
            finalResponse.NextPartitionKey = response.NextPartitionKey;
            finalResponse.NextRowKey = response.NextRowKey;
            finalResponse.PageCount = response.PageCount;
            finalResponse.PageCount = response.PageIndex;
            finalResponse.PageSize = response.PageSize;
            finalResponse.ResultId = response.ResultId;
            finalResponse.HasMoreRecords = response.HasMoreRecords;
            return finalResponse;
        }

        public Task<ListResponse<ServiceTicketSummary>> GetClosedTicketsAsyncAsync(string orgId, ListRequest listRequest)
        {
            return GetServiceTickets(tkt => tkt.OwnerOrganization.Id == orgId && tkt.IsClosed == true, listRequest);
        }

        public Task<ListResponse<ServiceTicketSummary>> GetOpenTicketsAsyncAsync(string orgId, ListRequest listRequest)
        {
            return GetServiceTickets(tkt => tkt.OwnerOrganization.Id == orgId && tkt.IsClosed == false, listRequest);
        }

        public Task<ServiceTicket> GetServiceTicketAsync(string id)
        {
            return GetDocumentAsync(id);
        }

        public Task<ListResponse<ServiceTicketSummary>> GetTicketForDeviceAsync(string deviceId, string orgId, ListRequest listRequest)
        {
            return GetServiceTickets(tkt => tkt.OwnerOrganization.Id == orgId && tkt.Device != null && tkt.Device.Id == deviceId, listRequest);
        }

        public Task<ListResponse<ServiceTicketSummary>> GetTicketsForOrgAsync(string orgId, ListRequest listRequest)
        {
            return GetServiceTickets(tkt => tkt.OwnerOrganization.Id == orgId, listRequest);
        }

        public Task<ListResponse<ServiceTicketSummary>> GetTicketsWithStatusAsync(string statusId, string orgId, ListRequest listRequest)
        {
            return GetServiceTickets(tkt => tkt.OwnerOrganization.Id == orgId && tkt.Status != null && tkt.Status.Id == statusId, listRequest);
        }

        public Task UpdateServiceTicketAsync(ServiceTicket ticket)
        {
            return UpsertDocumentAsync(ticket);
        }

        public Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsByUserAsync(string userId, string orgId, ListRequest listRequest)
        {
            return GetServiceTickets(tkt => tkt.OwnerOrganization.Id == orgId && tkt.AssignedTo != null && tkt.AssignedTo.Id == userId, listRequest);
        }

        public Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsByTemplateAsync(string templateId, string orgId, ListRequest listRequest)
        {
            return GetServiceTickets(tkt => tkt.OwnerOrganization.Id == orgId && tkt.Template != null && tkt.Template.Id == templateId, listRequest);
        }

        public Task<ListResponse<ServiceTicketSummary>> GetServiceTicketsAsync(TicketFilter filter, string orgId, ListRequest listRequest)
        {
            Expression<Func<ServiceTicket, bool>> mthd = (exp => exp.OwnerOrganization.Id == orgId);
            if (filter.IsClosed.HasValue)
            {
                Expression<Func<ServiceTicket, bool>> closeExpression = (exp => exp.IsClosed == filter.IsClosed);
                var combined = Expression.And(mthd, closeExpression);
                mthd = Expression.Lambda<Func<ServiceTicket, bool>>(combined);
            }

            if (!String.IsNullOrEmpty(filter.StatusKey))
            {
                Expression<Func<ServiceTicket, bool>> closeExpression = (exp => exp.Status != null && exp.Status.Id == filter.StatusKey);
                var combined = Expression.And(mthd, closeExpression);
                mthd = Expression.Lambda<Func<ServiceTicket, bool>>(combined);
            }

            if (!String.IsNullOrEmpty(filter.TemplateId))
            {
                Expression<Func<ServiceTicket, bool>> closeExpression = (exp => exp.Template != null && exp.Template.Id == filter.TemplateId);
                var combined = Expression.And(mthd, closeExpression);
                mthd = Expression.Lambda<Func<ServiceTicket, bool>>(combined);
            }

            if (!String.IsNullOrEmpty(filter.UserId))
            {
                Expression<Func<ServiceTicket, bool>> closeExpression = (exp => exp.AssignedTo != null && exp.AssignedTo.Id == filter.TemplateId);
                var combined = Expression.And(mthd, closeExpression);
                mthd = Expression.Lambda<Func<ServiceTicket, bool>>(combined);
            }

            if (!String.IsNullOrEmpty(filter.DeviceId))
            {
                Expression<Func<ServiceTicket, bool>> closeExpression = (exp => exp.Device != null && exp.Device.Id == filter.TemplateId);
                var combined = Expression.And(mthd, closeExpression);
                mthd = Expression.Lambda<Func<ServiceTicket, bool>>(combined);
            }

            if (!String.IsNullOrEmpty(filter.ServiceBoardId))
            {
                Expression<Func<ServiceTicket, bool>> closeExpression = (exp => exp.ServiceBoard != null && exp.ServiceBoard.Id == filter.ServiceBoardId);
                var combined = Expression.And(mthd, closeExpression);
                mthd = Expression.Lambda<Func<ServiceTicket, bool>>(combined);
            }

            return GetServiceTickets(mthd, listRequest);
        }

        public Task<ListResponse<ServiceTicketSummary>> GetTicketsForBoardAsync(string boardId, ListRequest listRequest)
        {
            return GetServiceTickets(tkt => tkt.ServiceBoard != null && tkt.ServiceBoard.Id == boardId, listRequest);
        }
    }
}
