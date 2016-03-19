using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Earth_In_Beats.WebService.WCF.Contracts
{

    [DataContract]
    public class Result
    {

        [DataMember]
        public bool Success
        {
            get;
            set;
        }

        [DataMember]
        public string Message
        {
            get;
            set;
        }
    }

}