using System.Collections.Generic;
using System.Web.Security;
using FL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FL.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "FL.Models.ApplicationDbContext";
        }

		protected override void Seed(ApplicationDbContext context)
		{
			//users
			var passwordHash = new PasswordHasher();
			string password = passwordHash.HashPassword("1");
			User userCustomer = new User()
			{
				UserName = "customer",
				PasswordHash = password,
			};
			context.Users.AddOrUpdate(u => u.UserName, userCustomer);
			User userDirector = new User()
			{
				UserName = "director",
				PasswordHash = password,
			};
			context.Users.AddOrUpdate(u => u.UserName, userDirector);

			//roles
			IdentityRole roleCustomer = new IdentityRole("Customer");
			IdentityRole roleDirector = new IdentityRole("Director");

			IdentityUserRole identityUserRoleCustomer = new IdentityUserRole()
			{
				Role = roleCustomer,
				User = userCustomer,
			};
			context.UserRoles.Add(identityUserRoleCustomer);
			IdentityUserRole identityUserRoleDirector = new IdentityUserRole()
			{
				Role = roleDirector,
				User = userDirector,
			};
			context.UserRoles.Add(identityUserRoleDirector);

			


			//------------------------------
			Vacancy vacancy1 = new Vacancy()
			{
				Creator = userCustomer,
				Description = "Good vacancy",
				IsClosed = false,
				Name = ".Net developer"
			};
			context.Vacancies.AddOrUpdate(v => v.VacancyId, vacancy1);

			TarifData tarifData1 = new TarifData()
			{
				CreateDate = DateTime.Now,
				UpdateDate = DateTime.Now,
				Info = "Tarif will suit you if you are a begineer customer",
				Name = "Simple"
			};
			context.TarifsDatas.Add(tarifData1);

			AvailableTarif availableTarif1 = new AvailableTarif()
			{
				DurationDays = 30,
				StartDate = DateTime.Now,
				EndDate = DateTime.Now.AddDays(365),
				Price = 10,
				TarifData = tarifData1
			};
			context.AvailableTarifs.AddOrUpdate(a => a.AvailableTarifId, availableTarif1);
		}
    }
}
