using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinnWorks.Classes
{
	public class Order
	{
		public int ID { get; set; }
		public int extId { get; set; }
		public string Region { get; set; }
		public string Country { get; set; }
		public string OrderDate { get; set; }
		public string ShipDate { get; set; }
		public int UnitsSold { get; set; }
		public double UnitPrice { get; set; }
		public double UnitCost { get; set; }
	}
}
