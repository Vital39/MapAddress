using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserIdentity.Model;

namespace UserIdentity.Store
{
    public class CustomUserStore : UserStore<AppUser, AppRole, int,
         Model.CustomUserLogin, Model.CustomUserRole, CustomUserClaim>
    {
        //CustomUserStore(DbContext context)
        public CustomUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
