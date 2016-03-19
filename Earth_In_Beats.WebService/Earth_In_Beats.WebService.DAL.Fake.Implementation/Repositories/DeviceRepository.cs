using System.Linq;
using Earth_In_Beats.WebService.DAL.Contracts.Models;
using Earth_In_Beats.WebService.DAL.Contracts.Repository;

namespace Earth_In_Beats.WebService.DAL.Fake.Implementation.Repositories
{
	public class DeviceRepository : Repository<DeviceContextEntity>, IDeviceRepository
	{
		public DeviceContextEntity GetByDeviceKey(string deviceKey)
		{
			return Data.SingleOrDefault(o => o.DeviceKey == deviceKey);
		}
	}
}