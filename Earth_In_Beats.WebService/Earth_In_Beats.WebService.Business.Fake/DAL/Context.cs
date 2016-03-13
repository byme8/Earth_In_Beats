using Earth_In_Beats.WebService.Business.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Earth_In_Beats.WebService.Business.Fake.DAL
{
    public static class Context
    {
        public static List<DeviceContext> Devices = new List<DeviceContext>();
        public static List<Track> Tracks = new List<Track>();
    }
}
