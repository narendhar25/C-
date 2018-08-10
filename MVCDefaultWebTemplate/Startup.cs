using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCDefaultWebTemplate.Startup))]
namespace MVCDefaultWebTemplate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
