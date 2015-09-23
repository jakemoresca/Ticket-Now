using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Ticket_Now.Repository.Dtos;

namespace Ticket_Now.Repository.Repositories
{
    public interface IRoleRepository
    {
        Task<RoleDto> FindByName(string name);
        Task<IdentityResult> AddRole(RoleDto role);
        Task<bool> DeleteRole(string name);
        Task<RoleDto> UpdateRole(RoleDto updatedRole);
        List<RoleDto> GetAll();
    }
}