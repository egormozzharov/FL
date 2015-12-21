using System;
using System.Linq;
using System.Web.Mvc;
using FL.Models;
using FL.Services;
using FL.ViewModels;
using Microsoft.AspNet.Identity;


namespace FL.Controllers
{
	public class CommonController : Controller
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly PaymentController _paymentService;
		private readonly JobsController _jobsService;

		public CommonController()
		{
			_dbContext = new ApplicationDbContext();
			_paymentService = new PaymentController(_dbContext);
			_jobsService = new JobsController(_dbContext);
		}

		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public ActionResult Payment(int tarifId)
		{
			AvailableTarif tarif = _dbContext.AvailableTarifs.ToList().First(t => t.AvailableTarifId == tarifId);
			Payment payment = new Payment() { AmountOfMoney = tarif.Price };
			PaymentViewModel paymentViewModel = new PaymentViewModel()
			{
				Payment = payment,
				TarifId = tarif.AvailableTarifId,
			};
			return View("Payment", paymentViewModel);
		}

		[HttpPost]
		public ActionResult SubmitPayment(PaymentViewModel paymentViewModel)
		{
			User currentUser = _dbContext.Users.ToList().First(u => u.Id == User.Identity.GetUserId());
			AvailableTarif tarif = _dbContext.AvailableTarifs.ToList().First(t => t.AvailableTarifId == paymentViewModel.TarifId);
			TarifSale sale = new TarifSale()
			{
				Buyer = currentUser,
				StartDate = DateTime.Now.ToString(),
				EndDate = DateTime.Now.AddDays(tarif.DurationDays).ToString(),
				Payment = paymentViewModel.Payment,
				Tarif = tarif,
			};

			bool result = _paymentService.PerformSaleOperation(sale);

			return View("PaymentResult", result);
		}

		[HttpGet]
		public ActionResult ApplyForTheJob(int jobId)
		{
			User currentUser = _dbContext.Users.ToList().First(u => u.Id == User.Identity.GetUserId());
			Vacancy vacancy = _dbContext.Vacancies.ToList().First(v => v.VacancyId == jobId);
			bool result = _jobsService.ApplyForTheJob(currentUser, vacancy);
			return View("ApplyForTheJobResultPage", result);
		}
	}
}