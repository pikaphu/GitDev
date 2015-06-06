using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMVCTest1.Startup))]
namespace WebMVCTest1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
