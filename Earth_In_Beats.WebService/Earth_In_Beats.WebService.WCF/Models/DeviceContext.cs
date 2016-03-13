using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Earth_In_Beats.WebService.WCF.Models
{
    [DataContract]
    public class DeviceContextData
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public double Latitude { get; set; }

        [DataMember]
        public double Longitude { get; set; }
    }
}