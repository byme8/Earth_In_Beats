using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Earth_In_Beats.WebService.Business.Contracts.Models
{
    public class Device
    {
        public Guid PublicKey { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Track CurrentTrack { get; set; }
    }
}
