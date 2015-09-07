using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Ticket_Now.UserPortal.Web.Startup))]
namespace Ticket_Now.UserPortal.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
