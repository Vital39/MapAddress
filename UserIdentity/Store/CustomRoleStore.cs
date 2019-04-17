using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserIdentity.Model;

namespace UserIdentity.Store
{
    public class CustomRoleStore : RoleStore<AppRole, int, CustomUserRole>
    {
        public CustomRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
