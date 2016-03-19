using System;
using System.Runtime.Serialization;
using Earth_In_Beats.WebService.WCF.Models;

namespace Earth_In_Beats.WebService.WCF.Contracts
{
    [DataContract]
    public class GetAllRequest
    {
        [DataMember]
        public Guid Id
        {
            get;
            set;
        }
    }

    [DataContract]
    public class GetAllResponce : Result
    {
        [DataMember]
        public DeviceData[] Devices
        {
            get;
            set;
        }
    }
}