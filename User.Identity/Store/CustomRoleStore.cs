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
    public class CustomRoleStore : RoleStore<AppRole, int, CustomUserRole>
    {
        public CustomRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
