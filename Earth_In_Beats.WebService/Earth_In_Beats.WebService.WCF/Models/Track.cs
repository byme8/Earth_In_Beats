using System.Runtime.Serialization;

namespace Earth_In_Beats.WebService.WCF.Models
{
    [DataContract]
    public class TrackData
    {
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Artist { get; set; }
    }
}