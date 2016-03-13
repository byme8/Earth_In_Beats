using System;

namespace Earth_In_Beats.WebService.DAL.Contracts.Models
{
    public class TrackEntity : Entity
    {
        public string Title { get; set; }

        public string Artist { get; set; }

        public Guid DeviceId { get; set; }

        public virtual DeviceContextEntity Device { get; set; }
    }
}