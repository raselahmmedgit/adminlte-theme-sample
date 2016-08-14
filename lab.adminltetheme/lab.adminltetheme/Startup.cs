using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lab.adminltetheme.Startup))]
namespace lab.adminltetheme
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
