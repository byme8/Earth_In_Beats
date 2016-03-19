using System;
using Earth_In_Beats.WebService.Business.Contracts.Models;

namespace Earth_In_Beats.WebService.Business.Contracts.Services
{
    public interface ITrackService
    {
        bool Play(Guid id, Track track);
        bool Stop(Guid id);
    }
}
