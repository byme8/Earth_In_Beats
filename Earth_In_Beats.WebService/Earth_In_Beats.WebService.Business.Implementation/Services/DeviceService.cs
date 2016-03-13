using System;
using System.Collections.Generic;
using Earth_In_Beats.WebService.Business.Contracts.Models;
using Earth_In_Beats.WebService.Business.Contracts.Services;
using Earth_In_Beats.WebService.DAL.Contracts.Models;
using Earth_In_Beats.WebService.DAL.Contracts.Repository;
using static Earth_In_Beats.WebService.Business.Implementation.Mapper.Mapper;

namespace Earth_In_Beats.WebService.Business.Implementation.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            this.deviceRepository = deviceRepository;
        }

        public DeviceContext Connect(string deviceKey)
        {
            var device = this.deviceRepository.GetByDeviceKey(deviceKey);

			if (device == null)
				device = this.deviceRepository.Add(new DeviceContextEntity
				{
					DeviceKey = deviceKey,
					Latitude = double.NaN,
					Longitude = double.NaN,
					PublicKey = Guid.NewGuid(),
					Status = DeviceStatus.Online
				});

			return  Map<DeviceContext, DeviceContextEntity>(device); 
        }

        public bool Disconnect(DeviceContext device)
        {
			var entity = this.deviceRepository.Get(device.Id);

			if (entity == null)
				return false;

			entity.Status = DeviceStatus.Offline;

			this.deviceRepository.Update(entity);

			return true;
        }

        public IEnumerable<Device> GetAll()
        {
			return Map<IEnumerable<Device>, IEnumerable<DeviceContextEntity>>(this.deviceRepository.GetAll());
        }

        public DeviceContext Update(DeviceContext device)
        {
			var entity = this.deviceRepository.Update(Map<DeviceContextEntity, DeviceContext>(device));

			return Map<DeviceContext, DeviceContextEntity>(entity);
        }
    }
}
