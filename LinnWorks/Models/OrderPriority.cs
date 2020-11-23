using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinnWorks.Models
{
	public class OrderPriority:DBModel
	{
		public OrderPriority()
		{
			Orders = new HashSet<Order>();
		}
		public int id { get; set; }
		public string name { get; set; }
		public ICollection<Order> Orders { get; set; }
	}
}
