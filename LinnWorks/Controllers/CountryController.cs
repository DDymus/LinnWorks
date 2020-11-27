using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinnWorks.Classes;
using LinnWorks.Data;
using LinnWorks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinnWorks.Controllers
{
	[Route( "[controller]" )]
	[ApiController]
	public class CountryController : ControllerBase
	{
		private readonly DataBaseContext context;
		public CountryController( DataBaseContext context )
		{
			this.context = context;
		}
		[HttpGet]
		public IEnumerable<Country> GetCountries()
		{
			return context.Countries.ToArray();
		}
	}
}
