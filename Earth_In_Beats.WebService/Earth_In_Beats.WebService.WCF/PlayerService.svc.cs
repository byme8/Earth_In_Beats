using System.Collections.Generic;
using System.ServiceModel;
using Earth_In_Beats.WebService.IoC;
using Earth_In_Beats.WebService.WCF.Models;
using Earth_In_Beats.WebService.Business.Contracts.Models;
using Earth_In_Beats.WebService.Business.Contracts.Services;
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
        public DeviceContextData Connect(string deviceKey)
        {
            var device = deviceService.Connect(deviceKey);

            return Map<DeviceContextData, DeviceContext>(device);
        }

        [OperationContract]
        public bool Disconnect(DeviceContextData device)
        {
            var data = deviceService.Disconnect(Map<DeviceContext, DeviceContextData>(device));

            return data;
        }

        [OperationContract]
        public IEnumerable<DeviceData> Get()
        {
            var data = deviceService.GetAll();

            return Map<IEnumerable<DeviceData>, IEnumerable<Device>>(data);
        }

        [OperationContract]
        public DeviceContextData Update(DeviceContextData device)
        {
            var data = deviceService.Update(Map<DeviceContext, DeviceContextData>(device));


            return Map<DeviceContextData, DeviceContext>(data);
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
