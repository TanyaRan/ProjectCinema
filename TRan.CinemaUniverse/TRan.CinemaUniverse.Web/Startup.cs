using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TRan.CinemaUniverse.Web.Startup))]
namespace TRan.CinemaUniverse.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
