using System;
using FL.Models;


namespace FL.Services
{
	public class JobsController
	{
		private DatabaseManager _dbManager;

		public JobsController(DatabaseManager dbManager)
		{
			this._dbManager = dbManager;
		}

		public bool ApplyForTheJob(User user, Vacancy vacancy)
		{
			VacancyApplie vacancyApplie = new VacancyApplie()
			{
				ApplyDate = DateTime.Now.ToString(),
				Selected = false,
				User = user,
				Vacancy = vacancy
			};
			return _dbManager.AddVacancyApply(vacancyApplie);
		}
	}
}