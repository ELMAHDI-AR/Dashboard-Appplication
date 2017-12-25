using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApplicationDashboardMVC.Startup))]
namespace ApplicationDashboardMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
