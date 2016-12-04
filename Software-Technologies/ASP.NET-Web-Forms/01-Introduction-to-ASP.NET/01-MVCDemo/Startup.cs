using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_1._2.MVC_Demo.Startup))]
namespace _1._2.MVC_Demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
