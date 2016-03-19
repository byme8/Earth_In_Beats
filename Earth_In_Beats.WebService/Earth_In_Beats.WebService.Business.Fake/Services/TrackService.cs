using System.Linq;
using Earth_In_Beats.WebService.Business.Fake.DAL;
using Earth_In_Beats.WebService.Business.Contracts.Services;
using Earth_In_Beats.WebService.Business.Contracts.Models;
using System;

namespace Earth_In_Beats.WebService.Business.Fake.Services
{
    public class TrackService : ITrackService
    {
        public bool Play(Guid id, Track track)
        {
            if (Context.Devices.Any(o => o.Id != id))
                return false;

            Context.Tracks.Add(track);

            return true;
        }

        public bool Stop(Guid id)
        {
            return true;
        }
    }
}
