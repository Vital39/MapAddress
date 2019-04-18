using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserIdentity.Model;
using UserIdentity.Store;

namespace UserIdentity.Manager
{
        public class ApplicationRoleManager : RoleManager<AppRole, int>
        {
            public ApplicationRoleManager(IRoleStore<AppRole, int> roleStore)
                : base(roleStore)
            {

            }

            public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options,
                             IOwinContext context)
            {
                return new ApplicationRoleManager(new RoleStore<AppRole, int, CustomUserRole>(context.Get<ApplicationDbContext>()));
            }
        }
}
