using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinnWorks.Models
{
	/**Import class - saved everu time import is done. Keeps track of what is imported, when, from what file, can be enhanced to keep statistics (nr of omported new rows/ modified rows etc.)*/
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
