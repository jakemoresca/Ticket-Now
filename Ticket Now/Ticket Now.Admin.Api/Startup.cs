using Microsoft.Owin;
using Owin;

[assembly: OwinStartup("AdminApiConfiguration", typeof(Ticket_Now.Admin.Api.Startup))]

namespace Ticket_Now.Admin.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
