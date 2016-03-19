using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Earth_In_Beats.WebService.WCF.Contracts
{
    [DataContract]
    public class DisconnectRequest
    {
        [DataMember]
        public Guid Id
        {
            get;
            set;
        }
    }

    [DataContract]
    public class DisconnectResponce : Result
    {

    }
}