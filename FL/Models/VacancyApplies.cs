using System;
using System.ComponentModel.DataAnnotations;

namespace FL.Models
{
	public class VacancyApplie
	{
		public VacancyApplie()
		{
			this.User = new User();
			this.Vacancy = new Vacancy();
			this.Selected = false;
		}

		[Key]
		public int VacancyAppliesId { get; set; }

		public User User { get; set; }

		public Vacancy Vacancy { get; set; }

		public bool Selected { get; set; }

		public String ApplyDate { get; set; }
	}
}