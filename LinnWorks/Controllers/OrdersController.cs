using LinnWorks.Classes;
using LinnWorks.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
		public IEnumerable<Order> Get( int countryId)
		{
			List<Order> toReturn = new List<Order>();
			foreach(LinnWorks.Models.Order order in context.Orders.Include( x=> x.Country).Include( x => x.Region).Where( x=> ( x.CountryId == countryId || countryId == 0)).OrderBy(x=> x.OrderDate))
			{
				toReturn.Add( new Order()
				{
					ID = order.OrderId,
					extId = order.OrderIdExt,
					Region = order.Region.Name,
					Country = order.Country.Name,
					OrderDate = order.OrderDate.ToString(),
					ShipDate = order.ShipDate.ToString(),
					UnitsSold = order.UnitsSold,
					UnitCost = order.UnitCost,
					UnitPrice = order.UnitPrice
				} );
			}
			return toReturn;
		}
		[HttpDelete]
		public void Delete (int id )
		{
			context.Orders.Remove( context.Orders.Find( id ) );
			context.SaveChanges();
		}
	}
}
