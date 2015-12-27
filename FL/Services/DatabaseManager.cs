using System.Collections.Generic;
using System.Linq;
using FL.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FL.Services
{
	public class DatabaseManager
	{
		private ApplicationDbContext _dbContext = new ApplicationDbContext();

		public DatabaseManager()
		{
		}

		public bool AddVacancyApply(VacancyApplie vacancyApplie)
		{
			_dbContext.VacancyApplies.Add(vacancyApplie);
			_dbContext.SaveChanges();
			return true;
		}

		public User GetUserById(string id)
		{
			return _dbContext.Users.ToList().First(u => u.Id == id);
		}

		public AvailableTarif GetAvailableTarifById(int id)
		{
			return _dbContext.AvailableTarifs.ToList().First(t => t.AvailableTarifId == id);
		}

		public Vacancy GetVacancyById(int id)
		{
			return _dbContext.Vacancies.ToList().First(v => v.VacancyId == id);
		}

		public Payment AddPayment(Payment payment)
		{
			_dbContext.Payments.Add(payment);
			_dbContext.SaveChanges();
			return _dbContext.Payments.ToList().Last();
		}

		public bool AddSale(TarifSale sale)
		{
			_dbContext.TarifSales.Add(sale);
			_dbContext.SaveChanges();
			return true;
		}

		public IEnumerable<IdentityUser> GetFreelancersByName(string name)
		{
			IdentityRole freelancerRole = GetRoleByName("Freelancer");
			return _dbContext.UserRoles.ToList().Where(ur => ur.Role.Id == freelancerRole.Id)
				.Select(ur => ur.User);
		}

		public IdentityRole GetRoleByName(string name)
		{
			return _dbContext.Roles.ToList().FirstOrDefault(r => r.Name == name);
		}
	}
}