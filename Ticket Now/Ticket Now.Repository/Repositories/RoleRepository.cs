using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using Ticket_Now.Repository.Dtos;

namespace Ticket_Now.Repository.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<RoleDto> _roleManager;

        public RoleRepository(RoleManager<RoleDto> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<RoleDto> FindByName(string name)
        {
            var role = await _roleManager.FindByNameAsync(name);
            return role;
        }

        public async Task<IdentityResult> AddRole(RoleDto role)
        {
            var result = await _roleManager.CreateAsync(role);
            return result;
        }

        public async Task<bool> DeleteRole(string name)
        {
            var role = await _roleManager.FindByNameAsync(name);
            var result = await _roleManager.DeleteAsync(role);
            return result.Succeeded;
        }

        public async Task<RoleDto> UpdateRole(RoleDto updatedRole)
        {
            var role = await _roleManager.FindByNameAsync(updatedRole.Name);
            role.Name = updatedRole.Name;

            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
                return role;
            throw new Exception("An error occured while updating role.");
        }

        public List<RoleDto> GetAll()
        {
            return _roleManager.Roles.ToList();
        }
    }
}
