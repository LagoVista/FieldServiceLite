// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: 92068b584ffec378b269019d54bcf89cb994912b548a458ed4ebec72b3022830
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Models.UIMetaData;
using LagoVista.FSLite.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin.Interfaces
{
    public interface IServiceBoardRepo
    {
        Task AddServiceBoardAsync(ServiceBoard board);
        Task UpdateServiceBoardAsync(ServiceBoard board);
        Task<ServiceBoard> GetServiceBoardAsync(string id);
        Task DeleteServiceBoardAsync(string id);
        Task<int> GetNextTicketNumber(string id);
        Task<ListResponse<ServiceBoardSummary>> GetServiceBoardForOrgAsync(string orgId, ListRequest listRequest);
        Task<bool> QueryKeyInUseAsync(string key, string orgId);
    }
}
