using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Ticket_Now.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.ObjectBuilder2;
using Ticket_Now.Repository.Daos;

namespace Ticket_Now.Repository.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUserDto> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _ctx;

        public AuthRepository(UserManager<ApplicationUserDto> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext ctx)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _ctx = ctx;
        }

        public async Task<ApplicationUserDto> FindUser(string userName, string password)
        {
            var user = await _userManager.FindAsync(userName, password);
            
            return user;
        }

        public async Task<ApplicationUserDto> FindByName(string name)
        {
            var user = await _userManager.FindByNameAsync(name);

            return user;
        }

        public async Task<IdentityResult> RegisterUser(ApplicationUserDto userModel)
        {
            var user = new ApplicationUserDto
            {
                Email = userModel.Email,
                PasswordHash = userModel.PasswordHash,
                UserName = userModel.UserName,
                Hometown = userModel.Hometown,
                ZipCode = userModel.ZipCode
            };

            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
                UpdateClaims(userModel, user);

            await AssignRole(user, userModel.RoleId);
            result = await _userManager.UpdateAsync(user);

            return result;
        }

        public async Task<bool> DeleteUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<ApplicationUserDto> UpdateUser(ApplicationUserDto updatedUser)
        {
            var user = await _userManager.FindByNameAsync(updatedUser.UserName);
            user.PasswordHash = updatedUser.PasswordHash;
            user.Hometown = updatedUser.Hometown;
            user.ZipCode = updatedUser.ZipCode;

            user = UpdateClaims(updatedUser, user);
            await RemoveRoles(user);
            await AssignRole(user, updatedUser.RoleId);

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
                return user;
            throw new Exception("Error occured while updating user.");
        }

        public List<ApplicationUserDto> GetAllUser()
        {
            return _ctx.Users.Include(u => u.Roles).ToList();
        }

        private ApplicationUserDto UpdateClaims(ApplicationUserDto updatedUser, ApplicationUserDto currentUser)
        {
            currentUser.Claims.ForEach(c =>
            {
                if (IsClaimRemoved(c, updatedUser.Claims))
                    RemoveClaim(c.UserId, c.ClaimType);
            });

            updatedUser.Claims.ForEach(c =>
            {
                if (IsNewClaim(c))
                    currentUser.Claims.Add(c);
            });

            return currentUser;
        }

        private async Task<IdentityResult> AssignRole(ApplicationUserDto user, string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            return await _userManager.AddToRolesAsync(user.Id, role.Name);
        }

        private async Task<IdentityResult> RemoveRoles(ApplicationUserDto user)
        {
            var roles = _roleManager.Roles.Select(r => r.Name).ToArray();
            return await _userManager.RemoveFromRolesAsync(user.Id, roles);
        }

        private bool IsNewClaim(IdentityUserClaim claim)
        {
            return claim.Id == 0;
        }

        private bool IsClaimRemoved(IdentityUserClaim claim, IEnumerable<IdentityUserClaim> updatedClaims)
        {
            return updatedClaims.All(uc => uc.ClaimType != claim.ClaimType && uc.Id > 0);
        }

        private void RemoveClaim(string userId, string claimType)
        {
            _ctx.Database.ExecuteSqlCommand("DELETE AspNetUserClaims WHERE ClaimType = @Type AND UserId = @UserId",
                        new SqlParameter("@Type", claimType),
                        new SqlParameter("@UserId", userId));
        }
    }
}