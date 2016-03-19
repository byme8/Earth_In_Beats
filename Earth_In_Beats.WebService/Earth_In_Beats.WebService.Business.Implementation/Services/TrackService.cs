using System;
using Earth_In_Beats.WebService.Business.Contracts.Models;
using Earth_In_Beats.WebService.Business.Contracts.Services;
using Earth_In_Beats.WebService.DAL.Contracts.Models;
using Earth_In_Beats.WebService.DAL.Contracts.Repository;
using static Earth_In_Beats.WebService.Business.Implementation.Mapper.Mapper;

namespace Earth_In_Beats.WebService.Business.Implementation.Services
{
	public class TrackService : ITrackService
	{
		private readonly IDeviceRepository deviceRepository;
        private readonly IRepository<TrackEntity> trackRepository;

        public TrackService(IDeviceRepository deviceRepository, IRepository<TrackEntity> trackRepository)
		{
			this.deviceRepository = deviceRepository;
            this.trackRepository = trackRepository;
		}

		public bool Play(Guid id, Track track)
		{
			var deviceEntity = deviceRepository.Get(id);

			if (deviceEntity == null)
				throw new InvalidOperationException($"Device with id = {id} doesn't exist.");

            trackRepository.Add(new TrackEntity { Artist = track.Artist, Title = track.Title, DeviceId = id});

			deviceEntity.Status = DeviceStatus.Play;
			deviceRepository.Save();


			return true;
		}

		public bool Stop(Guid id)
		{
			var deviceEntity = deviceRepository.Get(id);

			if (deviceEntity == null)
				throw new InvalidOperationException($"Device with id = {id} doesn't exist.");

			deviceEntity.Status = DeviceStatus.Online;
			deviceRepository.Save();

			return true;
		}
	}
}