using System;
using FL.Models;

namespace FL.Services
{
	public class PaymentController
	{
		private DatabaseManager _dbDatabaseManager;

		public PaymentController(DatabaseManager databaseManager)
		{
			this._dbDatabaseManager = databaseManager;
		}

		public bool PerformSaleOperation(TarifSale sale)
		{
			sale.Payment = MakePayment(sale.Payment);
			return _dbDatabaseManager.AddSale(sale);
		}

		private Payment MakePayment(Payment payment)
		{
			payment.Date = DateTime.Now.ToString();
			return _dbDatabaseManager.AddPayment(payment);
		}
	}
}