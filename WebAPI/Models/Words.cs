using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
	public class Words
	{
		public int  WordId { get; set; }
		public string  Word { get; set; }
		public int  WordTypeId { get; set; }
	}
}