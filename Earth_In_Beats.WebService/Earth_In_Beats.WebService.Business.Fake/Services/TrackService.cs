using System.Linq;
using Earth_In_Beats.WebService.Business.Fake.DAL;
using Earth_In_Beats.WebService.Business.Contracts.Services;
using Earth_In_Beats.WebService.Business.Contracts.Models;

namespace Earth_In_Beats.WebService.Business.Fake.Services
{
    public class TrackService : ITrackService
    {
        public bool Play(DeviceContext device, Track track)
        {
            if (Context.Devices.Any(o => o.Id != device.Id))
                return false;

            Context.Tracks.Add(track);

            return true;
        }

        public bool Stop(DeviceContext device)
        {
            return true;
        }
    }
}
