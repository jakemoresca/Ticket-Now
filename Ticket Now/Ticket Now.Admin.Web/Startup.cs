using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Ticket_Now.Admin.Web.Startup))]

namespace Ticket_Now.Admin.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
