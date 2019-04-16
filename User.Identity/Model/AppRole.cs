using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Identity.Model
{
    public class AppRole : IdentityRole<int, CustomUserRole>
    {
        public AppRole() { }
        public AppRole(string name) { Name = name; }
    }
}
