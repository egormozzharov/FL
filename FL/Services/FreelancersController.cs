
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FL.Services
{
	public class FreelancersController
	{
		private DatabaseManager _dbDatabaseManager;

		public FreelancersController(DatabaseManager dbManager)
		{
			this._dbDatabaseManager = dbManager;
		}

		public IEnumerable<IdentityUser> GetFreelancersByName(string name)
		{
			return _dbDatabaseManager.GetFreelancersByName(name);
		} 
	}
}