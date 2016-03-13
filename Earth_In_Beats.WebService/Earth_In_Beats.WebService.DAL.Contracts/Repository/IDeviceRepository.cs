using Earth_In_Beats.WebService.DAL.Contracts.Models;

namespace Earth_In_Beats.WebService.DAL.Contracts.Repository
{
    public interface IDeviceRepository : IRepository<DeviceContextEntity>
    {
        DeviceContextEntity GetByDeviceKey(string deviceKey);
    }
}
