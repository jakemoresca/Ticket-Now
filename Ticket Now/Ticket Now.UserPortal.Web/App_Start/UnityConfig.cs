using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using System.Web;
using Ticket_Now.Repository.Daos;
using Ticket_Now.Repository.Dtos;
using Ticket_Now.Repository.Mappers;
using Ticket_Now.Repository.Repositories;

namespace Ticket_Now.UserPortal.Web.App_Start
{
    public class UnityConfig
    {

        public static void CreateUnityContainer(IUnityContainer unityContainer)
        {
            //Dao
            //unityContainer.RegisterType<IStandardDao<PostDto>, PostDao>();
            unityContainer.RegisterType<ApplicationDbContext>();

            //Identity
            unityContainer.RegisterType<IAuthenticationManager>(
                new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));

            unityContainer.RegisterType<IUserStore<ApplicationUserDto>, UserStore<ApplicationUserDto>>(
                new InjectionConstructor(typeof(ApplicationDbContext)));

            unityContainer.RegisterType<UserManager<ApplicationUserDto>>();

            var userManagerOptions = new IdentityFactoryOptions<ApplicationUserManager>();
            userManagerOptions.DataProtectionProvider = Startup.DataProtectionProvider;

            unityContainer.RegisterType<ApplicationUserManager>(
                new InjectionConstructor(typeof(IUserStore<ApplicationUserDto>), userManagerOptions));

            //Repository
            unityContainer.RegisterType<IAuthRepository, AuthRepository>();

            //Mapper
            unityContainer.RegisterType<IUserMapper, UserMapper>();
            unityContainer.RegisterType<IClaimMapper, ClaimMapper>();
        }
    }
}