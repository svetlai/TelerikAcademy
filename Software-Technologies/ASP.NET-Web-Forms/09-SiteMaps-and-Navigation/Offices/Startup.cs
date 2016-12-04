using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Offices.Startup))]
namespace Offices
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
