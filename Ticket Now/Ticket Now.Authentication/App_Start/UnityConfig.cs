using Microsoft.Practices.Unity;
using Ticket_Now.Repository.Daos;
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

            //Repository
            unityContainer.RegisterType<IAuthRepository, AuthRepository>();

            //Mapper
            unityContainer.RegisterType<IUserMapper, UserMapper>();

            unityContainer.RegisterType<ApplicationDbContext>(new HierarchicalLifetimeManager());
        }
    }
}