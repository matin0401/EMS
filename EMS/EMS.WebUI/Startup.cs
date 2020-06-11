using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EMS.WebUI.Startup))]
namespace EMS.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
