using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Earth_In_Beats.WebService.DAL.Contracts.Models
{
    public class Entity
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;

		public bool Deleted { get; set; }
	}
}
