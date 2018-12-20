using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ADDemo.Startup))]
namespace ADDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
