using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinnWorks.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinnWorks.Controllers
{
	[Route( "[controller]" )]
	[ApiController]
	public class ReportController : ControllerBase
	{
		[HttpGet]
		public IEnumerable<ReportModel> Get()
		{
			List<ReportModel> toReturn = new List<ReportModel>();
			return toReturn;
		}
	}
}
