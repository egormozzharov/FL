using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FL.Models;
using FL.Services;
using FL.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace FL.Controllers
{
	public class CommonController : Controller
	{
		private readonly DatabaseManager _dbDatabaseManager;
		private readonly PaymentController _paymentService;
		private readonly JobsController _jobsService;
		private readonly FreelancersController _freelancersController;

		public CommonController()
		{
			_dbDatabaseManager = new DatabaseManager();
			_paymentService = new PaymentController(_dbDatabaseManager);
			_jobsService = new JobsController(_dbDatabaseManager);
			_freelancersController = new FreelancersController(_dbDatabaseManager);
		}

		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public ActionResult Payment(int tarifId)
		{
			AvailableTarif tarif = _dbDatabaseManager.GetAvailableTarifById(tarifId);
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
			User currentUser = _dbDatabaseManager.GetUserById(User.Identity.GetUserId());
			AvailableTarif tarif = _dbDatabaseManager.GetAvailableTarifById(paymentViewModel.TarifId);
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
			User currentUser = _dbDatabaseManager.GetUserById(User.Identity.GetUserId());
			Vacancy vacancy = _dbDatabaseManager.GetVacancyById(jobId);
			bool result = _jobsService.ApplyForTheJob(currentUser, vacancy);
			return View("ApplyForTheJobResultPage", result);
		}

		[HttpGet]
		public ActionResult GetFreelancers(string name = "")
		{
			IEnumerable<IdentityUser> freelancers = _freelancersController.GetFreelancersByName(name);
			return View("FreelancersList", freelancers);
		}
	}
}