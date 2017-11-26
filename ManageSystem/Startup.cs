using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManageSystem.Startup))]
namespace ManageSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
