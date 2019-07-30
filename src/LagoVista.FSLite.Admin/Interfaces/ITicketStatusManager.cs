using LagoVista.Core.Models;
using LagoVista.Core.Models.UIMetaData;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin.Interfaces
{
    public interface ITicketStatusManager
    {
        Task<InvokeResult> AddTicketStatusDefinitionAsync(TicketStatusDefinition ticketStatusItems, EntityHeader org, EntityHeader user);
        Task<InvokeResult> UpdateTicketStatusDefinitionAsync(TicketStatusDefinition ticketStatusItems, EntityHeader org, EntityHeader user);
        Task<InvokeResult> DeleteTicketStatusDefinitionAsync(string id, EntityHeader org, EntityHeader user);
        Task<TicketStatusDefinition> GetTicketStatusDefinitionAsync(string id, EntityHeader org, EntityHeader user);
        Task<ListResponse<TicketStatusDefinitionSummary>> GetTicketStatusDefinitionForOrgsAsync(ListRequest listRequest, EntityHeader org, EntityHeader user);
        Task<DependentObjectCheckResult> CheckInUseAsync(string id, EntityHeader org, EntityHeader user);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
    }
}
