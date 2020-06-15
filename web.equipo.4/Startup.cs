using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(web.equipo._4.StartupOwin))]

namespace web.equipo._4
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
