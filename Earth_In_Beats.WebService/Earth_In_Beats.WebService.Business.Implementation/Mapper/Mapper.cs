using Earth_In_Beats.WebService.Business.Contracts.Models;
using Earth_In_Beats.WebService.DAL.Contracts.Models;

namespace Earth_In_Beats.WebService.Business.Implementation.Mapper
{
	public static class Mapper
	{
		static Mapper()
		{
			AutoMapper.Mapper.Initialize((configuration) =>
			{
				configuration.CreateMap<TrackEntity, Track>();
				configuration.CreateMap<Track, TrackEntity>();

				configuration.CreateMap<DeviceContextEntity, Device>();
				configuration.CreateMap<Device, DeviceContextEntity>();

				configuration.CreateMap<DeviceContextEntity, DeviceContext>();
				configuration.CreateMap<DeviceContext, DeviceContextEntity>();
			});
		}


		public static TDestination Map<TDestination, TSource>(TSource source)
		{
			return AutoMapper.Mapper.Map<TDestination>(source);
		}
	}
}
