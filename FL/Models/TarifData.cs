using System;
using System.ComponentModel.DataAnnotations;

namespace FL.Models
{
	public class TarifData
	{
		[Key]
		public int TarifId { get; set; }

		public string Name { get; set; }

		public string Info { get; set; }

		public String CreateDate { get; set; }

		public String UpdateDate { get; set; }
	}
}