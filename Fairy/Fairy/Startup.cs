using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fairy.Startup))]
namespace Fairy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
