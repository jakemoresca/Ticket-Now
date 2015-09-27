using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ticket_Now.Repository.Repositories
{
    public interface IRoleRepository
    {
        Task<IdentityRole> FindByName(string name);
        Task<IdentityResult> AddRole(IdentityRole role);
        Task<bool> DeleteRole(string id);
        Task<IdentityRole> UpdateRole(IdentityRole updatedRole);

        Task<IdentityRole> AssignUserRole(string userId, string roleId);
        List<IdentityRole> GetAll();
    }
}