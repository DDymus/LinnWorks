using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinnWorks.Models
{
	public class Import : DBModel
	{
		public Import()
		{
			Orders = new HashSet<Order>();
		}
		public int ImportId { get; set; }
		public string OriginalFileName{ get; set; }
		public ICollection<Order> Orders { get; set; }
	}
}
