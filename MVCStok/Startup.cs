using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCStok.Startup))]
namespace MVCStok
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
