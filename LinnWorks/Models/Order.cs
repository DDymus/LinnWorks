using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LinnWorks.Models
{
	/*Order DB Object. Country, Region, Type, Priority are referenced as IDs to corresponding DB items.*/
	public class Order : DBModel
	{
		public int OrderId { get; set; }
		public DateTime OrderDate { get; set; }
		public int OrderIdExt { get; set; }
		public DateTime ShipDate { get; set; }
		public int UnitsSold { get; set; }
		public double UnitPrice { get; set; }
		public double UnitCost { get; set; }
		public double TotalRevenue { get; set; }
		public double TotalCost { get; set; }
		public double TotalProfit { get; set; }
		public int RegionId { get; set; }
		public Region Region { get; set; }
		public int CountryId { get; set; }
		public Country Country { get; set; }
		public int ImportId { get; set; }
		public Import Import { get; set; }
		public int ItemTypeId { get; set; }
		public ItemType ItemType { get; set; }
		public int OrderPriorityId { get; set; }
		public OrderPriority OrderPriority { get; set; }
	}
}
