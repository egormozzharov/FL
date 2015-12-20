using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FL.Models
{
	public class ApplicationDbContext : IdentityDbContext<User>
	{
		public ApplicationDbContext()
			: base("DefaultConnection")
		{
		}

		public DbSet<Vacancy> Vacancies { get; set; }

		public DbSet<VacancyApplie> VacancyApplies { get; set; }

		public DbSet<TarifData> TarifsDatas { get; set; }

		public DbSet<AvailableTarif> AvailableTarifs { get; set; }

		public DbSet<TarifSale> TarifSales { get; set; }

		public DbSet<Payment> Payments { get; set; }

		public DbSet<IdentityUserRole> UserRoles { get; set; }
	}
}