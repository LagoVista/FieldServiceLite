// --- BEGIN CODE INDEX META (do not edit) ---
// ContentHash: ae6bc31c57ab1e8072b61d9a60380cc1a4bf3a03c152f655128400a4c5dcf4fc
// IndexVersion: 2
// --- END CODE INDEX META ---
using LagoVista.Core.Models.UIMetaData;
using LagoVista.IoT.DeviceManagement.Models;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin.Interfaces
{
    public interface IDeviceExceptionLogger
    {
        Task AddDeviceExceptionAsync(DeviceException exception);

        Task<ListResponse<DeviceException>> GetExceptionsForDeviceAsync(string deviceRepoId, string deviceId, ListRequest listRequest);
    }
}
