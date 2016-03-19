using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Earth_In_Beats.WebService.WCF.Models;

namespace Earth_In_Beats.WebService.WCF.Contracts
{
    [DataContract]
    public class ConnectRequest
    {
        [DataMember]
        public string DeviceKey;
    }

    [DataContract]
    public class ConnectResponce : Result
    {
        [DataMember]
        public Guid Id
        {
            get;
            set;
        }
    }
}