using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SecurityGuard.Web.Startup))]
namespace SecurityGuard.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
