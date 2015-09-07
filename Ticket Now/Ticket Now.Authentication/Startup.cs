using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Owin;
using System;
using System.Web.Http;
using Ticket_Now.Authentication.App_Start;
using Ticket_Now.Authentication.Providers;
using Ticket_Now.Repository.Repositories;

[assembly: OwinStartup(typeof(Ticket_Now.Authentication.Startup))]
namespace Ticket_Now.Authentication
{
    public class Startup
    {
        public virtual HttpConfiguration GetInjectionConfiguration()
        {
            var config = new HttpConfiguration();
            var container = new UnityContainer();
            UnityConfig.CreateUnityContainer(container);
            config.DependencyResolver = new UnityResolver(container);
            return config;
        }

        public void Configuration(IAppBuilder app)
        {
            var config = GetInjectionConfiguration();
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider((IAuthRepository)config.DependencyResolver.GetService(typeof(IAuthRepository)))
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
    }
}