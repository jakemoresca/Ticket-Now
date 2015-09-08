using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using System.Data.Entity;
using System.Web;
using Ticket_Now.Authentication.Controllers;
using Ticket_Now.Repository;
using Ticket_Now.Repository.Daos;
using Ticket_Now.Repository.Dtos;
using Ticket_Now.Repository.Mappers;
using Ticket_Now.Repository.Repositories;

namespace Ticket_Now.Authentication.App_Start
{
    public class UnityConfig
    {

        public static void CreateUnityContainer(IUnityContainer unityContainer)
        {
            ////Dao
            //unityContainer.RegisterType<IStandardDao<PostDto>, PostDao>();

            unityContainer.RegisterType<UserManager<ApplicationUserDto>>();

            //Repository
            unityContainer.RegisterType<IAuthRepository, AuthRepository>();

            //Mapper
            unityContainer.RegisterType<IUserMapper, UserMapper>();

            //unityContainer.RegisterType<DbContext, ApplicationDbContext>();
            //unityContainer.RegisterType<ApplicationUserManager>();

            var userManagerOptions = new IdentityFactoryOptions<ApplicationUserManager>();
            userManagerOptions.DataProtectionProvider = Startup.DataProtectionProvider;


            unityContainer.RegisterType<ApplicationDbContext>();
            unityContainer.RegisterType<ApplicationUserManager>(
                new InjectionConstructor(typeof(IUserStore<ApplicationUserDto>), userManagerOptions));

            unityContainer.RegisterType<IAuthenticationManager>(
                new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));

            unityContainer.RegisterType<IUserStore<ApplicationUserDto>, UserStore<ApplicationUserDto>>(
                new InjectionConstructor(typeof(ApplicationDbContext)));
        }
    }
}