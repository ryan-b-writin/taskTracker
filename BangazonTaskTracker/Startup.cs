using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BangazonTaskTracker.Startup))]
namespace BangazonTaskTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
