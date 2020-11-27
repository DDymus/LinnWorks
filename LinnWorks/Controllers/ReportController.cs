using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinnWorks.Classes;
using LinnWorks.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinnWorks.Controllers
{
	[Route( "[controller]" )]
	[ApiController]
	public class ReportController : ControllerBase
	{
		private readonly DataBaseContext context;
		public ReportController(DataBaseContext context)
		{
			this.context = context;
		}
		[HttpGet]
		public IEnumerable<ReportModel> Get()
		{
			return context.Orders.GroupBy( x => new { x.CountryId, x.OrderDate.Year } ).Select( g => new {
				CountryID = g.Key.CountryId,
				Year = g.Key.Year,
				Count = g.Count(),
				Profit = g.Sum( c => c.TotalProfit )
			}).Join(context.Countries, p=> p.CountryID, e=>e.CountryId, (p,e) => new ReportModel {
				CountryName = e.Name,
				CountryID = e.CountryId,
				Count = p.Count,
				Year = p.Year,
				Profit = p.Profit
			} ).OrderBy( x=>x.CountryName).ThenBy(x=>x.Year).ToArray();
			
		}
	}
}
