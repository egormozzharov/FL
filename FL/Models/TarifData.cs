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

		public DateTime CreateDate { get; set; }

		public DateTime UpdateDate { get; set; }
	}
}