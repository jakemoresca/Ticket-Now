using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Ticket_Now.Identity.Startup))]

namespace Ticket_Now.Identity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
