using System.ComponentModel.DataAnnotations;

namespace FL.Models
{
	public class Vacancy
	{
		public Vacancy()
		{
			this.Creator = new User();
		}

		[Key]
		public int VacancyId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public virtual User Creator { get; set; }

		public bool IsClosed { get; set; }
	}
}