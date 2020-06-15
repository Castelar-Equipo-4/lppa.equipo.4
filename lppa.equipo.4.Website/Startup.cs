using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lppa.equipo._4.Website.Startup))]
namespace lppa.equipo._4.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
