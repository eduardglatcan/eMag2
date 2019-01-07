using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eMag2.Startup))]
namespace eMag2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
