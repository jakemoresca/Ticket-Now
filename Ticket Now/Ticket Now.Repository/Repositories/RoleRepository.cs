using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ticket_Now.Repository.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleRepository(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IdentityRole> FindByName(string name)
        {
            var role = await _roleManager.FindByNameAsync(name);
            return role;
        }

        public async Task<IdentityResult> AddRole(IdentityRole role)
        {
            role.Id = Guid.NewGuid().ToString();
            var result = await _roleManager.CreateAsync(role);
            return result;
        }

        public async Task<bool> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            var result = await _roleManager.DeleteAsync(role);
            return result.Succeeded;
        }

        public async Task<IdentityRole> UpdateRole(IdentityRole updatedRole)
        {
            var role = await _roleManager.FindByIdAsync(updatedRole.Id);
            role.Name = updatedRole.Name;
            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
                return role;
            throw new Exception("An error occured while updating role.");
        }

        public async Task<IdentityRole> AssignUserRole(string userId, string roleId)
        {
            var userRole = new IdentityUserRole {RoleId = roleId, UserId = userId};
            var role = await _roleManager.FindByIdAsync(roleId);
            role.Users.Add(userRole);

            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
                return role;
            throw new Exception("An error occured while updating role.");
        }

        public List<IdentityRole> GetAll()
        {
            return _roleManager.Roles.ToList();
        }
    }
}
