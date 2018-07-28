using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheBeerWar.Startup))]
namespace TheBeerWar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
