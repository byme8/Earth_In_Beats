using Earth_In_Beats.WebService.Business.Contracts.Models;
using System.Collections.Generic;
using System;

namespace Earth_In_Beats.WebService.Business.Contracts.Services
{
    public interface IDeviceService
    {
        DeviceContext Connect(string deviceKey);
        DeviceContext Update(DeviceContext device);
        bool Disconnect(Guid id);
        IEnumerable<Device> GetAll(Guid id);
    }
}
