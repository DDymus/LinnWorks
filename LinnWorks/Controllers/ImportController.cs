using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinnWorks.Classes;
using LinnWorks.Data;
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
			List<Import> toReturn = new List<Import>();
			foreach(Models.Import import in context.Imports.OrderBy(x => x.LastModifyDttm))
			{
				toReturn.Add( new Import() {  id = import.ImportId, LastModifyDttm=import.LastModifyDttm.ToString(), LastModifyUserId = import.LAstModifyUserId, OriginalFileName = import.OriginalFileName} );
			}
			return toReturn;
		}
	}
}
