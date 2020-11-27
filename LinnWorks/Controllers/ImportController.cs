using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinnWorks.Classes;
using LinnWorks.Data;
using LinnWorks.Models;
using Microsoft.AspNetCore.Mvc;

namespace LinnWorks.Controllers
{
	[ApiController]
	[Route( "[controller]" )]
	public class ImportController
	{
		private readonly DataBaseContext context;
		public ImportController(DataBaseContext context )
		{
			this.context = context;
		}
		[HttpGet]
		public IEnumerable<Import> GetImports()
		{
			return context.Imports.OrderBy( x => x.LastModifyDttm ).ToArray();
		}
	}
}
