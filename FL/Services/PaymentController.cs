using System;
using System.Linq;
using FL.Models;

namespace FL.Services
{
	public class PaymentController
	{
		private ApplicationDbContext _dbContext;

		public PaymentController(ApplicationDbContext dbContext)
		{
			this._dbContext = dbContext;
		}

		public bool PerformSaleOperation(TarifSale sale)
		{
			sale.Payment = MakePayment(sale.Payment);
			_dbContext.TarifSales.Add(sale);
			_dbContext.SaveChanges();
			return true;
		}

		private Payment MakePayment(Payment payment)
		{
			payment.Date = DateTime.Now.ToString();
			_dbContext.Payments.Add(payment);
			_dbContext.SaveChanges();
			return _dbContext.Payments.ToList().Last();
		}
	}
}