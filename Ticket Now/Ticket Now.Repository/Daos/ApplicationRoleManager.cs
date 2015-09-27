using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ticket_Now.Repository.Daos
{
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole, string> store)
        : base(store)
        {
            RoleValidator = new RoleValidator<IdentityRole>(this)
            {
                
            };
        }
    }
}
