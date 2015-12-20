using System;
using System.ComponentModel.DataAnnotations;

namespace FL.Models
{
	public class AvailableTarif
	{
		public AvailableTarif()
		{
			this.TarifData = new TarifData();
		}

		[Key]
		public int AvailableTarifId { get; set; }

		public int Price { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public int DurationDays { get; set; }

		public virtual TarifData TarifData { get; set; }
	}
}