using System;
using System.Collections.Generic;
using System.Linq;
using Earth_In_Beats.WebService.Business.Fake.DAL;
using Earth_In_Beats.WebService.Business.Contracts.Services;
using Earth_In_Beats.WebService.Business.Contracts.Models;

namespace Earth_In_Beats.WebService.Business.Fake.Services
{
    public class DeviceService : IDeviceService
    {

        public  DeviceContext Connect(string deviceKey)
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

        public  bool Disconnect(DeviceContext device)
        {
            return Context.Devices.RemoveAll(o => o.Id == device.Id) > 0;
        }

        public  IEnumerable<Device> GetAll()
        {
            return Context.Devices.Select(o => new Device
            {
                PublicKey = o.Id,
                Latitude = o.Latitude,
                Longitude = o.Longitude,
                CurrentTrack = Context.Tracks.LastOrDefault()
            });
        }

        public  DeviceContext Update(DeviceContext device)
        {
            var data = Context.Devices.FirstOrDefault(o => o.Id == device.Id);

            data.Latitude = device.Latitude;
            data.Longitude = device.Longitude;

            return device;
        }
    }
}
