using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcMovieSampleApp.Startup))]
namespace MvcMovieSampleApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
