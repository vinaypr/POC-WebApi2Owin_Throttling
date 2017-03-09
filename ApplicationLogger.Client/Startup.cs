using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApplicationLogger.Client.Startup))]
namespace ApplicationLogger.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
