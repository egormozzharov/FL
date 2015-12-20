using FL.Models;
using Microsoft.AspNet.Identity;

namespace FL.Migrations
{
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
			ContextKey = "FL.Models.ApplicationDbContext";
		}

		protected override void Seed(ApplicationDbContext context)
		{
			var passwordHash = new PasswordHasher();
			string password = passwordHash.HashPassword("1");
			User user1 = new User()
			{
				UserName = "customer",
				PasswordHash = password,
			};
			context.Users.AddOrUpdate(u => u.UserName, user1);

			Vacancy vacancy1 = new Vacancy()
			{
				Creator = user1,
				Description = "Good vacancy",
				IsClosed = false,
				Name = ".Net developer"
			};
			context.Vacancies.AddOrUpdate(v => v.VacancyId, vacancy1);
		}
	}
}
