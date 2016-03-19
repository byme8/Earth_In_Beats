using System.Linq;
using System.ServiceModel;
using Earth_In_Beats.WebService.Business.Contracts.Models;
using Earth_In_Beats.WebService.Business.Contracts.Services;
using Earth_In_Beats.WebService.IoC;
using Earth_In_Beats.WebService.WCF.Contracts;
using Earth_In_Beats.WebService.WCF.Models;
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
        public ConnectResponce Connect(ConnectRequest request)
        {
            var device = deviceService.Connect(request.DeviceKey);

            return new ConnectResponce
            {
                Success = true,
                Id = device.Id
            };
        }

        [OperationContract]
        public DisconnectResponce Disconnect(DisconnectRequest request)
        {
            var data = deviceService.Disconnect(request.Id);

            return new DisconnectResponce
            {
                Success = true
            };
        }

        [OperationContract]
        public GetAllResponce Get(GetAllRequest request)
        {
            var data = deviceService.GetAll(request.Id).ToArray();

            return new GetAllResponce
            {
                Devices = Map<DeviceData[], Device[]>(data)
            };
        }

        [OperationContract]
        public UpdateResponce Update(UpdateRequst request)
        {
            var device = new DeviceContext
            {
                Id = request.Id,
                Latitude = request.Latitude,
                Longitude = request.Longitude
            };

            var data = deviceService.Update(device);


            return new UpdateResponce
            {
                Success = true,
                Device = Map<DeviceContextData, DeviceContext>(data)
            };
        }

        [OperationContract]
        public PlayResponce Play(PlayRequest request)
        {
            var result = this.trackService.Play(request.Id,
                new Track
                {
                    Artist = request.Artist,
                    Title = request.Title
                });

            return new PlayResponce
            {
                Success = result
            };
        }

        [OperationContract]
        public StopResponce Stop(StopRequest request)
        { 
            var result = this.trackService.Stop(request.Id);

            return new StopResponce 
            {
                Success = result
            };
        }
    }
}
