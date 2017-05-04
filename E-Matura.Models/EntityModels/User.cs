using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using E_Matura.Models.EntityModels.Interfaces;
using E_Matura.Models.EntityModels.Matura;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace E_Matura.Models.EntityModels
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
		public string FirstName { get; set; }
	    public string LastName { get; set; }
	    public IEnumerable<IQuestion> TakenQuestions { get; set; }
		public IEnumerable<IQuestion> AddedQuestions { get; set; }
        public IEnumerable<MaturaResult> MaturaResults { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}