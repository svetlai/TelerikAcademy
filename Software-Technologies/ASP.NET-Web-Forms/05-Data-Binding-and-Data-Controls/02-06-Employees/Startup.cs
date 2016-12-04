using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_5._2___5._6.Employees.Startup))]
namespace _5._2___5._6.Employees
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
