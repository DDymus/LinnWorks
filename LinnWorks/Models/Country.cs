using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinnWorks.Models
{
	public class Country : DBModel
	{
		public Country()
		{
			Orders = new HashSet<Order>();
		}
		public int CountryId { get; set; } 
		public string Name { get; set; }
		public ICollection<Order> Orders { get; set; }
	}
}
