// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: ed9315688c71e26834d9f80b24b4b0bca7597012dec897a35e63e0956f6a4d20
// IndexVersion: 2
// --- END CODE INDEX META ---
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
