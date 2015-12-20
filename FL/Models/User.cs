using Microsoft.AspNet.Identity.EntityFramework;

namespace FL.Models
{
	// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
	public class User : IdentityUser
	{
		public User()
		{
			IsBlocked = false;
			Address = "Default address";
		}

		public string Address { get; set; }

		public bool IsBlocked { get; set; }
	}
}