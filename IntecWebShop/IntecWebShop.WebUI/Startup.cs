using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IntecWebShop.WebUI.Startup))]
namespace IntecWebShop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
