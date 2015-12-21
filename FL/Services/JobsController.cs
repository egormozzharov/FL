using System;
using FL.Models;


namespace FL.Services
{
	public class JobsController
	{
		private ApplicationDbContext _dbContext;

		public JobsController(ApplicationDbContext dbContext)
		{
			this._dbContext = dbContext;
		}

		public bool ApplyForTheJob(User user, Vacancy vacancy)
		{
			_dbContext.VacancyApplies.Add(new VacancyApplie()
			{
				ApplyDate = DateTime.Now.ToString(), 
				Selected = false,
				User = user,
				Vacancy = vacancy
			});
			_dbContext.SaveChanges();
			return true;
		}
	}
}