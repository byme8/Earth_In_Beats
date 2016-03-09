using System;
using System.Runtime.Serialization;

namespace Earth_In_Beats.WebService.WCF.Models
{
    [DataContract]
    public class DeviceData
    {
        [DataMember]
        public Guid PublicKey { get; set; }

        [DataMember]
        public double Latitude { get; set; }

        [DataMember]
        public double Longitude { get; set; }

        [DataMember]
        public TrackData CurrentTrack { get; set; }
    }
}