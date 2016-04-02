using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Earth_In_Beats.WebService.DAL.Contracts.Models
{
    public class DeviceContextEntity : Entity
    {
        public string DeviceKey { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

		public DeviceStatus Status { get; set; }
    }

	public enum DeviceStatus
	{
		Online,
		Offline,
		Play
	}
}
