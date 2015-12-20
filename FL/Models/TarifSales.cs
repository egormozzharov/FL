using System;
using System.ComponentModel.DataAnnotations;

namespace FL.Models
{
	public class TarifSale
	{
		public TarifSale()
		{
			this.Buyer = new User();
			this.Tarif = new AvailableTarif();
			this.Payment = new Payment();
		}

		[Key]
		public int TarifSaleId { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public virtual User Buyer { get; set; }

		public virtual AvailableTarif Tarif { get; set; }

		public virtual Payment Payment { get; set; }
	}
}