using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_SmartVideo.Startup))]
namespace Web_SmartVideo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
