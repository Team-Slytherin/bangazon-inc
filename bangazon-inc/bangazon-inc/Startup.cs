using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bangazon_inc.Startup))]
namespace bangazon_inc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
