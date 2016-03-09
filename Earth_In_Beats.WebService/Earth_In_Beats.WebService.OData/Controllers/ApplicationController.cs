using Earth_In_Beats.WebService.Contracts.Services;
using System.Linq;
using System.Web.OData;
using Earth_In_Beats.WebService.Contracts.Models;
using System.Result;

namespace Earth_In_Beats.WebService.OData.Controllers
{
    [EnableQuery]
    public class DeviceController : ODataController, IDeviceService
    {
        private readonly IDeviceService deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            this.deviceService = deviceService;
        }

        public Result<DeviceContext> Connect(DeviceContext device)
        {
            return deviceService.Connect(device);
        }

        public Result<DeviceContext> Disconnect(DeviceContext device)
        {
            return deviceService.Connect(device);
        }

        public Result<IQueryable<Device>> Get()
        {
            return deviceService.Get();
        }

        public Result<DeviceContext> Update(DeviceContext device)
        {
            return deviceService.Connect(device);
        }
    }
}