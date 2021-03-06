﻿using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using Ticket_Now.Repository.Daos;
using Ticket_Now.Repository.Dtos;
using Ticket_Now.Repository.Mappers;
using Ticket_Now.Repository.Repositories;

namespace Ticket_Now.Admin.Api
{
    public class UnityConfig
    {

        public static void CreateUnityContainer(IUnityContainer unityContainer)
        {
            //Dao
            unityContainer.RegisterType<ApplicationDbContext>();

            //Identity
            unityContainer.RegisterType<IAuthenticationManager>(
                new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));

            unityContainer.RegisterType<IUserStore<ApplicationUserDto>, UserStore<ApplicationUserDto>>(
                new InjectionConstructor(typeof(ApplicationDbContext)));

            unityContainer.RegisterType<IRoleStore<IdentityRole, string>, RoleStore<IdentityRole>>(
                new InjectionConstructor(typeof (ApplicationDbContext)));
                
            unityContainer.RegisterType<UserManager<ApplicationUserDto>>();
            unityContainer.RegisterType<RoleManager<IdentityRole>>();

            var userManagerOptions = new IdentityFactoryOptions<ApplicationUserManager>
            {
                DataProtectionProvider = Startup.DataProtectionProvider
            };

            unityContainer.RegisterType<ApplicationUserManager>(
                new InjectionConstructor(typeof(IUserStore<ApplicationUserDto>), userManagerOptions));
            unityContainer.RegisterType<ApplicationRoleManager>(
                new InjectionConstructor(typeof(IRoleStore<IdentityRole, string>)));

            //Repository
            unityContainer.RegisterType<IAuthRepository, AuthRepository>();
            unityContainer.RegisterType<IRoleRepository, RoleRepository>();
            unityContainer.RegisterType<IRepository<LocationDto>, LocationRepository>();
            unityContainer.RegisterType<IRepository<EventDto>, EventRepository>();
            unityContainer.RegisterType<IRepository<ScheduleDto>, ScheduleRepository>();

            //Mapper
            unityContainer.RegisterType<IUserMapper, UserMapper>();
            unityContainer.RegisterType<IRoleMapper, RoleMapper>();
            unityContainer.RegisterType<IClaimMapper, ClaimMapper>();
            unityContainer.RegisterType<ILocationMapper, LocationMapper>();
            unityContainer.RegisterType<IEventMapper, EventMapper>();
            unityContainer.RegisterType<IScheduleMapper, ScheduleMapper>();
        }
    }
}