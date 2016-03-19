using System;
using System.Runtime.Serialization;
using Earth_In_Beats.WebService.WCF.Models;

namespace Earth_In_Beats.WebService.WCF.Contracts
{
    [DataContract]
    public class UpdateRequst
    {
        [DataMember]
        public Guid Id
        {
            get;
            set;
        }

        [DataMember]
        public double Latitude
        {
            get;
            set;
        }

        [DataMember]
        public double Longitude
        {
            get;
            set;
        }
    }

    [DataContract]
    public class UpdateResponce : Result
    {
        [DataMember]
        public DeviceContextData Device
        {
            get;
            set;
        }
    }

}