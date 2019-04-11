using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Identity.Model;
using static User.Identity.Model.AppUser;

namespace User.Identity.Store
{
    public class CustomUserStore : UserStore<AppUser, AppRole, int,
       CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        //CustomUserStore(DbContext context)
        public CustomUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
