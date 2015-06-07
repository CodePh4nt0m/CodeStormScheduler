using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodeStormScheduler.Startup))]
namespace CodeStormScheduler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
