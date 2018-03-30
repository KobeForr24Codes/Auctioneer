using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Auctioneer.Startup))]
namespace Auctioneer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
