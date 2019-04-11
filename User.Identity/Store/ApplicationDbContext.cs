using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Identity.Model;
using static User.Identity.Model.AppUser;

namespace User.Identity.Store
{
    public class DbInitialize : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        private async Task SeedAsync(ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {

            }
        }

    }

    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public ApplicationDbContext()
            : base()
        {
            if (!Database.Exists())
            {
                Database.SetInitializer<ApplicationDbContext>(new DbInitialize());
            }
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
