// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: ac59d2b18e189f8342a8fe1168d6f111e79a8dd52fcde8cff74f6c4d37249bb6
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
    public interface IServiceBoardManager
    {
        Task<InvokeResult> AddServiceBoardAsync(ServiceBoard serviceBoard, EntityHeader org, EntityHeader user);
        Task<InvokeResult> UpdateServiceBoardAsync(ServiceBoard serviceBoard, EntityHeader org, EntityHeader user);
        Task<InvokeResult> DeleteServiceBoardAsync(string id, EntityHeader org, EntityHeader user);
        Task<ServiceBoard> GetServiceBoardAsync(string id, EntityHeader org, EntityHeader user);
        Task<ListResponse<ServiceBoardSummary>> GetServiceBoardsAsync(ListRequest listRequest, EntityHeader org, EntityHeader user);

        Task<DependentObjectCheckResult> CheckInUseAsync(string id, EntityHeader org, EntityHeader user);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
    }
}
