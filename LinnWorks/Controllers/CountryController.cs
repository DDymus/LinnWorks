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
			List<Country> toReturn = new List<Country>();
			foreach(LinnWorks.Models.Country country in context.Countries)
			{
				toReturn.Add( new Country() { id = country.CountryId, name = country.Name } );
			}
			return toReturn;
		}
	}
}
