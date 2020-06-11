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
