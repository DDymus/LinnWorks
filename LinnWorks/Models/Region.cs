using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinnWorks.Models
{
	public class Region:DBModel
	{
		public Region()
		{
			Orders = new HashSet<Order>();
		}
		public int RegionId { get; set; }
		public string Name { get; set; }
		public ICollection<Order> Orders { get; set; }
	}
}
