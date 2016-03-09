using Earth_In_Beats.WebService.Contracts.Services;
using System.Collections.Generic;
using System.ServiceModel;
using Earth_In_Beats.WebService.IoC;
using Earth_In_Beats.WebService.WCF.Models;
using Earth_In_Beats.WebService.Contracts.Models;
using static Earth_In_Beats.WebService.WCF.Mapper.Mapper;

namespace Earth_In_Beats.WebService.WCF
{
    [ServiceContract]
    public class PlayerService
    {
        private readonly IDeviceService deviceService;
        private readonly ITrackService trackService;

        public PlayerService()
            : this(Resolver.Instance.Resolve<IDeviceService>(), Resolver.Instance.Resolve<ITrackService>())
        {

        }

        PlayerService(IDeviceService deviceService, ITrackService trackService)
        {
            this.deviceService = deviceService;
            this.trackService = trackService;
        }

        [OperationContract]
        public DeviceContextData Connect()
        {
            var data = deviceService.Connect();

            if (!data.Success)
                return null;

            return Map<DeviceContextData, DeviceContext>(data.Value);
        }

        [OperationContract]
        public bool Disconnect(DeviceContextData device)
        {
            var data = deviceService.Disconnect(Map<DeviceContext, DeviceContextData>(device));

            return data.Value;
        }

        [OperationContract]
        public IEnumerable<DeviceData> Get()
        {
            var data = deviceService.Get();

            return Map<IEnumerable<DeviceData>, IEnumerable<Device>>(data.Value);
        }

        [OperationContract]
        public DeviceContextData Update(DeviceContextData device)
        {
            var data = deviceService.Update(Map<DeviceContext, DeviceContextData>(device));

            if (!data.Success)
                return null;

            return Map<DeviceContextData, DeviceContext>(data.Value);
        }

        [OperationContract]
        public bool Play(DeviceContextData device, TrackData track)
        {
            return this.trackService.Play(Map<DeviceContext, DeviceContextData>(device), Map<Track, TrackData>(track));
        }

        [OperationContract]
        public bool Stop(DeviceContextData device)
        {
            return this.trackService.Stop(Map<DeviceContext, DeviceContextData>(device));
        }
    }
}
