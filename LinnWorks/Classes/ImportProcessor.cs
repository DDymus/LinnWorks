using LinnWorks.Data;
using LinnWorks.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LinnWorks.Classes
{
	public class ImportProcessor
	{
		private readonly DataBaseContext context;
		private DataTable values = null;
		private int user_id = 0;
		string original_file_name = null;
		public ImportProcessor(DataTable values, DataBaseContext context, int user_id, string original_file_name)
		{
			this.values = values;
			this.context = context;
			this.user_id = user_id;
			this.original_file_name = original_file_name;
		}

		internal void SaveToDataBase()
		{
			LinnWorks.Models.Import import = new LinnWorks.Models.Import();
			import.LAstModifyUserId = user_id;
			import.LastModifyDttm = DateTime.UtcNow;
			
			foreach(DataRow oRow in values.Rows)
			{
				string regionName = oRow["Region"].ToString();
				string countryName = oRow["Country"].ToString();
				string itemTypeName = oRow["Item Type"].ToString();
				string orderPriorityName = oRow["Order Priority"].ToString();
				int orderIdExt= Convert.ToInt32(oRow["Order ID"]);
				LinnWorks.Models.Order order = new LinnWorks.Models.Order();
				if(context.Orders.Where(x=>x.OrderIdExt == orderIdExt).Any())
				{
					order = context.Orders.Where(x => x.OrderIdExt == orderIdExt).FirstOrDefault();
				}
				else
				{
					context.Orders.Add(order);
				}
				order.OrderDate = Convert.ToDateTime(oRow["Order Date"]);
				order.OrderIdExt = orderIdExt;
				order.ShipDate = Convert.ToDateTime(oRow["Ship Date"]);
				order.UnitsSold = Convert.ToInt32(oRow["Units Sold"]);
				order.UnitPrice = Convert.ToDouble(oRow["Unit Cost"]);
				order.TotalRevenue = Convert.ToDouble(oRow["Total Revenue"]);
				order.TotalCost = Convert.ToDouble(oRow["Total Cost"]);
				order.TotalProfit = Convert.ToDouble(oRow["Total Profit"]);
				order.LastModifyDttm = DateTime.UtcNow;
				order.LAstModifyUserId = user_id;
				
				Region region = new Region();
				if (!context.Regions.Where(x => x.Name == regionName).Any())
				{
					region.Name = regionName;
					region.LastModifyDttm = DateTime.UtcNow;
					region.LAstModifyUserId = user_id;
					context.Regions.Add(region);
				}
				else
				{
					region = context.Regions.Where(x => x.Name == regionName).FirstOrDefault();
				}
				region.Orders.Add(order);
				LinnWorks.Models.Country country = new LinnWorks.Models.Country();
				if(!context.Countries.Where(x=>x.Name == countryName).Any())
				{
					country.Name = countryName;
					country.LastModifyDttm = DateTime.UtcNow;
					country.LAstModifyUserId = user_id;
					context.Countries.Add(country);
				}
				else
				{
					country = context.Countries.Where(x => x.Name == countryName).FirstOrDefault();
				}
				country.Orders.Add(order);
				ItemType itemType = new ItemType();
				if(!context.ItemTypes.Where(x=>x.Name == itemTypeName).Any())
				{
					itemType.Name = itemTypeName;
					itemType.LastModifyDttm = DateTime.UtcNow;
					itemType.LAstModifyUserId = user_id;
					context.ItemTypes.Add(itemType);
				}
				else
				{
					itemType = context.ItemTypes.Where(x => x.Name == itemTypeName).FirstOrDefault();
				}
				itemType.Orders.Add(order);
				OrderPriority orderPriority = new OrderPriority();
				if(!context.OrderPriorities.Where(x=>x.name == orderPriorityName).Any())
				{
					orderPriority.name = orderPriorityName;
					orderPriority.LastModifyDttm = DateTime.UtcNow;
					orderPriority.LAstModifyUserId = user_id;
					context.OrderPriorities.Add(orderPriority);
				}
				else
				{
					orderPriority = context.OrderPriorities.Where(x => x.name == orderPriorityName).FirstOrDefault();
				}
				orderPriority.Orders.Add(order);
				import.Orders.Add(order);
			}
			context.Imports.Add(import);
			context.SaveChanges();
		}
	}
}
