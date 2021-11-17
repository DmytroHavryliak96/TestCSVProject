using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestCsvProject.Startup))]
namespace TestCsvProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
