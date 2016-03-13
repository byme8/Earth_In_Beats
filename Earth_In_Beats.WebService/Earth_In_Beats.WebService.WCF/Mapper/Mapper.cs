using Earth_In_Beats.WebService.WCF.Models;
using Earth_In_Beats.WebService.Business.Contracts.Models;

namespace Earth_In_Beats.WebService.WCF.Mapper
{
    public static class Mapper
    {
        static Mapper()
        {
            AutoMapper.Mapper.Initialize((configuration) =>
            {
                configuration.CreateMap<TrackData, Track>();
                configuration.CreateMap<Track, TrackData>();

                configuration.CreateMap<DeviceData, Device>();
                configuration.CreateMap<Device, DeviceData>();

                configuration.CreateMap<DeviceContextData, DeviceContext>();
                configuration.CreateMap<DeviceContext, DeviceContextData>();
            });
        }


        public static TDestination Map<TDestination, TSource>(TSource source)
        {
            return AutoMapper.Mapper.Map<TDestination>(source);
        }
    }
}