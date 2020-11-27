using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinnWorks.Models
{
	/** base DB object class to store all common fields for DB object. current 2 fields can be used to track who made changes and when. (in case needed).*/
	public class DBModel
	{
		public int LastModifyUserId { get; set; }
		public DateTime LastModifyDttm { get; set; }
	}
}
