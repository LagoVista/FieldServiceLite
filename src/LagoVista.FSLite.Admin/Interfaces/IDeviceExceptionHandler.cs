using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.IoT.DeviceManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin
{
    public interface IDeviceExceptionHandler
    {
        Task<InvokeResult> HandleDeviceExceptionAsync(DeviceException exception, EntityHeader org, EntityHeader user);
    }
}
