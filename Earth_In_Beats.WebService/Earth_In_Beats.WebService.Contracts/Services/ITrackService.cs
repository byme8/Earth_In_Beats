using Earth_In_Beats.WebService.Business.Contracts.Models;

namespace Earth_In_Beats.WebService.Business.Contracts.Services
{
    public interface ITrackService
    {
        bool Play(DeviceContext device, Track track);
        bool Stop(DeviceContext device);
    }
}
