using LagoVista.Core.Models;
using LagoVista.Core.Validation;
using LagoVista.FSLite.Admin.Interfaces;
using LagoVista.IoT.Deployment.Admin;
using LagoVista.IoT.Deployment.Admin.Interfaces;
using LagoVista.IoT.Deployment.Admin.Repos;
using LagoVista.IoT.DeviceManagement.Core;
using LagoVista.IoT.DeviceManagement.Core.Managers;
using LagoVista.IoT.DeviceManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagoVista.FSLite.Admin.Managers
{
    public class DeviceExceptionHandler : IDeviceExceptionHandler
    {
        private readonly IDeviceExceptionLogger _exceptionLogger;
        private readonly IDeviceManager _deviceManager;
        private readonly IServiceTicketCreator _serviceTicketCreator;
        private readonly IDeviceConfigurationManager _deviceConfigManager;
        private readonly IDeviceRepositoryManager _repoManager;

        public DeviceExceptionHandler(IDeviceExceptionLogger exceptionLogger, IDeviceManager deviceManager, IServiceTicketCreator serviceTicketCreator, 
                                    IDeviceConfigurationManager deviceConfigManager, IDeviceRepositoryManager repoManager)
        {
            _exceptionLogger = exceptionLogger ?? throw new ArgumentNullException(nameof(exceptionLogger));
            _deviceManager = deviceManager ?? throw new ArgumentNullException(nameof(deviceManager));
            _serviceTicketCreator = serviceTicketCreator ?? throw new ArgumentNullException(nameof(serviceTicketCreator));
            _deviceConfigManager = deviceConfigManager ?? throw new ArgumentNullException(nameof(deviceConfigManager));
            _repoManager = repoManager ?? throw new ArgumentNullException(nameof(repoManager));
        }

        public async Task<InvokeResult> HandleDeviceExceptionAsync(DeviceException exception, EntityHeader org, EntityHeader user)
        {
            var repo = await _repoManager.GetDeviceRepositoryWithSecretsAsync(exception.DeviceRepositoryId, org, user);
            var device = await _deviceManager.GetDeviceByIdAsync(repo, exception.DeviceId, org, user);
            var deviceConfig = await _deviceConfigManager.GetDeviceConfigurationAsync(device.DeviceConfiguration.Id, org, user);

            var deviceErrorCode = deviceConfig.ErrorCodes.FirstOrDefault(err => err.Key == exception.ErrorCode);
            if(deviceErrorCode == null)
            {
                return InvokeResult.FromError($"Could not find error code [{exception.ErrorCode}] on device configuration [{deviceConfig.Name}] for device [{device.Name}]");
            }

            var ticket = await _serviceTicketCreator.CreateServiceTicketAsync(deviceErrorCode.ServiceTicketTemplate.Id, exception.DeviceRepositoryId, exception.DeviceId, exception.Details);

            return InvokeResult.Success;
        }
    }
}
    