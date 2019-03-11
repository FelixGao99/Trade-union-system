using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TradeUnionManageSystem.UI.Startup))]
namespace TradeUnionManageSystem.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
