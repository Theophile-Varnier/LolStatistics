using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LolStatistics.Web.Startup))]
namespace LolStatistics.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
