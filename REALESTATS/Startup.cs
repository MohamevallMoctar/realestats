using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(REALESTATS.Startup))]
namespace REALESTATS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
