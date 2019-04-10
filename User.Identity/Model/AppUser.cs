using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static User.Identity.Model.AppUser;

namespace User.Identity.Model
{
    class AppUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string Email { get; set; }
        public class CustomUserRole : IdentityUserRole<int>
        {
        }
        public class CustomUserClaim : IdentityUserClaim<int> { }
        public class CustomUserLogin : IdentityUserLogin<int> { }
    }
}
