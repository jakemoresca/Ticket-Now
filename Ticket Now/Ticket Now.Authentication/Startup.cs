using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Owin;
using System;
using System.Web.Http;
using Ticket_Now.Repository.Formats;
using Ticket_Now.Repository.Providers;
using Ticket_Now.Repository.Repositories;

[assembly: OwinStartup(typeof(Ticket_Now.Authentication.Startup))]
namespace Ticket_Now.Authentication
{
    public class Startup
    {
        // add this static variable
        internal static IDataProtectionProvider DataProtectionProvider { get; private set; }

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
            DataProtectionProvider = app.GetDataProtectionProvider();

            var config = GetInjectionConfiguration();
            //OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            //{
            //    AllowInsecureHttp = true,
            //    TokenEndpointPath = new PathString("/token"),
            //    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
            //    Provider = new SimpleAuthorizationServerProvider((IAuthRepository)config.DependencyResolver.GetService(typeof(IAuthRepository)))
            //};

            //// Token Generation
            //app.UseOAuthAuthorizationServer(OAuthServerOptions);
            //app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth2/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new ApplicationOAuthProvider((IAuthRepository)config.DependencyResolver.GetService(typeof(IAuthRepository))),
                AccessTokenFormat = new CustomJwtFormat("http://localhost/TicketNowAuth/")
            };

            // OAuth 2.0 Bearer Access Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);

            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
    }
}