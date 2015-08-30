using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Ticket_Now.Startup))]

namespace Ticket_Now
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
