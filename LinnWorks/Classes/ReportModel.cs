using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinnWorks.Classes
{
	public class ReportModel
	{
		public int CountryID { get; internal set; }
		public int Count { get; internal set; }
		public int Year { get; internal set; }
		public double Profit { get; internal set; }
		public string CountryName { get; internal set; }
	}
}
