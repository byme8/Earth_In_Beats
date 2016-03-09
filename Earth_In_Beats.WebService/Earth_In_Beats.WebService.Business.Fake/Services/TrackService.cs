using Earth_In_Beats.WebService.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Earth_In_Beats.WebService.Contracts.Models;
using System.Result;
using Earth_In_Beats.WebService.Business.Fake.DAL;

namespace Earth_In_Beats.WebService.Business.Fake.Services
{
    public class TrackService : ITrackService
    {
        public Result<bool> Play(DeviceContext device, Track track)
        {
            if (Context.Devices.Any(o => o.Id != device.Id))
                return false;

            Context.Tracks.Add(track);

            return true;
        }

        public Result<bool> Stop(DeviceContext device)
        {
            return true;
        }
    }
}
