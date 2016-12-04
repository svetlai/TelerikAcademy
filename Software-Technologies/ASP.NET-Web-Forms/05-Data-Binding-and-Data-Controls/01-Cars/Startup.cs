using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_5._1.Cars.Startup))]
namespace _5._1.Cars
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
