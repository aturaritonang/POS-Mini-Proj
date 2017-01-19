using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectPOS.Web.Startup))]
namespace ProjectPOS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
