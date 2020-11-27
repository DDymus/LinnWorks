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
			List<ReportModel> toReturn = new List<ReportModel>();
			context.Orders.GroupBy(x => new { x.CountryId, x.OrderDate.Year }).Select(g => new
			{
				CountryID = g.Key.CountryId,
				Year = g.Key.Year,
				Count = g.Count(),
				Profit = g.Sum(c=>c.TotalProfit)
			}).ToArray();
			return toReturn;
		}
	}
}
