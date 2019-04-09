using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UserIdentity.Startup))]
namespace UserIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
