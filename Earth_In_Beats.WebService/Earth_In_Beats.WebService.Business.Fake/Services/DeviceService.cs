using Earth_In_Beats.WebService.Contracts.Services;
using System;
using System.Collections.Generic;
using Earth_In_Beats.WebService.Contracts.Models;
using System.Result;
using System.Linq;
using Earth_In_Beats.WebService.Business.Fake.DAL;

namespace Earth_In_Beats.WebService.Business.Fake.Services
{
    public class DeviceService : IDeviceService
    {

        public Result<DeviceContext> Connect()
        {
            var device = new DeviceContext
            {
                Id = Guid.NewGuid(),
                Latitude = double.NaN,
                Longitude = double.NaN
            };

            Context.Devices.Add(device);

            return device;
        }

        public Result<bool> Disconnect(DeviceContext device)
        {
            return Context.Devices.RemoveAll(o => o.Id == device.Id) > 0;
        }

        public Result<IEnumerable<Device>> Get()
        {
            return new Result<IEnumerable<Device>>(Context.Devices.Select(o => new Device
            {
                PublicKey = o.Id,
                Latitude = o.Latitude,
                Longitude = o.Longitude,
                CurrentTrack = Context.Tracks.LastOrDefault()
            }));
        }

        public Result<DeviceContext> Update(DeviceContext device)
        {
            var data = Context.Devices.FirstOrDefault(o => o.Id == device.Id);

            data.Latitude = device.Latitude;
            data.Longitude = device.Longitude;

            return device;
        }
    }
}
