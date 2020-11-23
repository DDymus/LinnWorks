using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinnWorks.Data
{
	public class DataBaseInitializer
	{
		public static void Initialize(DataBaseContext context)
		{
			context.Database.EnsureCreated();
		}
	}
}
