using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheSuperHeroProject.Startup))]
namespace TheSuperHeroProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
