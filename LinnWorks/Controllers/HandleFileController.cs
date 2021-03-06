﻿using LinnWorks.Classes;
using LinnWorks.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LinnWorks.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class HandleFileController : ControllerBase
	{
		private readonly DataBaseContext context;
		public HandleFileController (DataBaseContext context)
		{
			this.context = context;
		}
		[HttpPost]
		[DisableRequestSizeLimit]
		[RequestFormLimits(ValueLengthLimit =int.MaxValue, MultipartBodyLengthLimit =int.MaxValue)]
		public IActionResult PostFile()
		{
			IFormFile file = Request.Form.Files[0];
			Stream stream = file.OpenReadStream();
			DataTable dt = GetDataTable(stream);
			ImportProcessor import = new ImportProcessor(dt, context,1, file.FileName);
			import.SaveToDataBase();
			return Ok( "OK") ;
		}

		private DataTable GetDataTable(Stream stream)
		{
			DataTable dt = new DataTable();
			StreamReader sr = new StreamReader(stream);
			string[] columns = sr.ReadLine().Split(",");
			foreach(string column in columns)
			{
				dt.Columns.Add(column, typeof(string));
			}
			string line;
			while ((line = sr.ReadLine()) != null)
			{
				string[] values = line.Split(",");
				DataRow oRow = dt.NewRow();
				for (int i = 0; i< values.Length;i++)
				{
					oRow[i] = values[i];
				}
				dt.Rows.Add(oRow);
			}
			return dt;
		}
	}
}
