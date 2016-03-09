using Earth_In_Beats.WebService.Contracts.Models;
using System.Result;

namespace Earth_In_Beats.WebService.Contracts.Services
{
    public interface ITrackService
    {
        Result<bool> Play(DeviceContext device, Track track);
        Result<bool> Stop(DeviceContext device);
    }
}
