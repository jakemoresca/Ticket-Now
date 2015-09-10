using Owin;
using Microsoft.Owin.Security.DataProtection;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Ticket_Now.UserPortal.Web.App_Start;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security;

namespace Ticket_Now.UserPortal.Web
{
    public partial class Startup
    {
        //public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        internal static IDataProtectionProvider DataProtectionProvider { get; private set; }

        public virtual HttpConfiguration GetInjectionConfiguration()
        {
            var config = new HttpConfiguration();
            var container = new UnityContainer();
            UnityConfig.CreateUnityContainer(container);
            config.DependencyResolver = new UnityResolver(container);
            return config;
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            DataProtectionProvider = app.GetDataProtectionProvider();

            var config = GetInjectionConfiguration();

            var issuer = "http://localhost/TicketNowAuth/";
            var audience = "099153c2625149bc8ecb3e85e03f0022";
            var secret = TextEncodings.Base64Url.Decode("IxrAjDoa2FqElO7IhrSrUJELhUckePEPVpaePlS_Xaw");

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audience },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
                    }
                });

            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        //public static string PublicClientId { get; private set; }

        //// For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        //public void ConfigureAuth(IAppBuilder app)
        //{
        //    // Configure the db context and user manager to use a single instance per request
        //    //app.CreatePerOwinContext(ApplicationDbContext.Create);
        //    //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

        //    // Enable the application to use a cookie to store information for the signed in user
        //    // and to use a cookie to temporarily store information about a user logging in with a third party login provider
        //    app.UseCookieAuthentication(new CookieAuthenticationOptions());
        //    app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

        //    // Configure the application for OAuth based flow
        //    PublicClientId = "self";

        //    OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
        //    {
        //        AllowInsecureHttp = true,
        //        TokenEndpointPath = new PathString("/token"),
        //        AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
        //        Provider = new SimpleAuthorizationServerProvider((IAuthRepository)config.DependencyResolver.GetService(typeof(IAuthRepository)))
        //    };

        //    // Token Generation
        //    app.UseOAuthAuthorizationServer(OAuthServerOptions);
        //    app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        //    // Uncomment the following lines to enable logging in with third party login providers
        //    //app.UseMicrosoftAccountAuthentication(
        //    //    clientId: "",
        //    //    clientSecret: "");

        //    //app.UseTwitterAuthentication(
        //    //    consumerKey: "",
        //    //    consumerSecret: "");

        //    //app.UseFacebookAuthentication(
        //    //    appId: "",
        //    //    appSecret: "");

        //    //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
        //    //{
        //    //    ClientId = "",
        //    //    ClientSecret = ""
        //    //});
        //}
    }
}
