using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TicketNow.UserPortal.Api.Startup))]

namespace TicketNow.UserPortal.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
