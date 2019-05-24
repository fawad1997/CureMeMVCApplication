using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cure_Me.Startup))]
namespace Cure_Me
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
