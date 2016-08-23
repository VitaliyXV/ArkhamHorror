using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArkhamHorrorControlPanel.Startup))]
namespace ArkhamHorrorControlPanel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
