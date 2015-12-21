using System;
using System.ComponentModel.DataAnnotations;

namespace FL.Models
{
	public class Payment
	{
		[Key]
		public int PaymentId { get; set; }

		public int FromAccountNumber { get; set; }

		public int AmountOfMoney { get; set; }

		public String Date { get; set; }
	}
}