using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ticket_Now.Repository;
using Ticket_Now.Repository.Daos;

namespace Ticket_Now.UserPortal.Web.App_Start
{
    public class UnityConfig
    {

        public static void CreateUnityContainer(IUnityContainer unityContainer)
        {
            ////Dao
            //unityContainer.RegisterType<IStandardDao<PostDto>, PostDao>();

            ////Repository
            //unityContainer.RegisterType<IPostRepository, PostRepository>();

            ////Mapper
            //unityContainer.RegisterType<IPostMapper, PostMapper>();
        }
    }
}