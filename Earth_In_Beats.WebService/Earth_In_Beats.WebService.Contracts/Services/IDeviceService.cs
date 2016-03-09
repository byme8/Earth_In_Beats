using Earth_In_Beats.WebService.Contracts.Models;
using System.Collections.Generic;
using System.Result;

namespace Earth_In_Beats.WebService.Contracts.Services
{
    public interface IDeviceService
    {
        Result<DeviceContext> Connect();
        Result<DeviceContext> Update(DeviceContext device);
        Result<bool> Disconnect(DeviceContext device);
        Result<IEnumerable<Device>> Get();
    }
}
