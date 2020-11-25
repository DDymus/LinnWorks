using LinnWorks.Classes;
using LinnWorks.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinnWorks.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly DataBaseContext context;
		public OrdersController(DataBaseContext context)
		{
			this.context = context;
		}
		[HttpGet]
		public IEnumerable<Order> GetImports( int countryId)
		{
			List<Order> toReturn = new List<Order>();
			foreach(LinnWorks.Models.Order order in context.Orders.Where( x=> x.CountryId == 1))
			{
				toReturn.Add(new Order() { ID = order.CountryId, OrderID = order.OrderIdExt, Region = order.Region.Name });
			}
			return toReturn;
		}
	}
}
