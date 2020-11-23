using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinnWorks.Models
{
	public class ItemType:DBModel
	{
		public ItemType()
		{
			Orders = new HashSet<Order>();
		}
		public int ItemTypeId { get; set; }
		public string Name { get; set; }
		public ICollection<Order> Orders { get; set; }
	}
}
