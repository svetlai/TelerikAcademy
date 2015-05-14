using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewsSite.Web.Startup))]
namespace NewsSite.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
