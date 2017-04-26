using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace E_Matura.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EMaturaContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        //protected override void Seed(EMaturaContext context)
   //     {
	  //      if (!context.Roles.Any(role => role.Name == "Student"))
	  //      {
		 //       var store = new RoleStore<IdentityRole>(context);
		 //       var manager = new RoleManager<IdentityRole>(store);
			//	var role = new IdentityRole("Student");
			//	manager.Create(role);
	  //      }
			//if (!context.Roles.Any(role => role.Name == "Teacher"))
			//{
			//	var store = new RoleStore<IdentityRole>(context);
			//	var manager = new RoleManager<IdentityRole>(store);
			//	var role = new IdentityRole("Teacher");
			//	manager.Create(role);
			//}
			//if (!context.Roles.Any(role => role.Name == "Admin"))
			//{
			//	var store = new RoleStore<IdentityRole>(context);
			//	var manager = new RoleManager<IdentityRole>(store);
			//	var role = new IdentityRole("Admin");
			//	manager.Create(role);
			//}

		//}
    }
}
