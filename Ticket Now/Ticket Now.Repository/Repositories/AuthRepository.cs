using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Ticket_Now.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
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
        private readonly ApplicationDbContext _ctx;

        public AuthRepository(UserManager<ApplicationUserDto> userManager, ApplicationDbContext ctx)
        {
            _userManager = userManager;
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
            var result = await _userManager.CreateAsync(userModel);

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

            #region claims removal
            var claimsToRemove = new List<IdentityUserClaim>();

            user.Claims.ForEach(c =>
            {
                if (IsClaimRemoved(c, updatedUser.Claims))
                    claimsToRemove.Add(c);
            });



            claimsToRemove.ForEach(c =>
            {
                user.Claims.Remove(c);

                _ctx.Database.ExecuteSqlCommand("DELETE AspNetUserClaims WHERE ClaimType = @Type AND UserId = @UserId",
                    new SqlParameter("@Type", c.ClaimType),
                    new SqlParameter("@UserId", user.Id));
            });
            #endregion

            #region claims insertion
            updatedUser.Claims.ForEach(c =>
            {
                if (IsNewClaim(c))
                    user.Claims.Add(c);
            });
            #endregion

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
                return user;
            throw new Exception("Error occured while updating user.");
        }

        public List<ApplicationUserDto> GetAllUser()
        {
            return _ctx.Users.ToList();
        }

        private bool IsNewClaim(IdentityUserClaim claim)
        {
            return claim.Id == 0;
        }

        private bool IsClaimRemoved(IdentityUserClaim claim, IEnumerable<IdentityUserClaim> updatedClaims)
        {
            return updatedClaims.All(uc => uc.ClaimType != claim.ClaimType);
        }

        public async Task<IdentityUserClaim> AddUserClaim(IdentityUserClaim claim, string userName)
        {
            var user = await _userManager.FindByEmailAsync(userName);
            if (user.Claims.All(uc => uc.ClaimType != claim.ClaimType))
                user.Claims.Add(claim);
            else
                throw new Exception("Claims already exists.");

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
                return user.Claims.FirstOrDefault(cu => cu.ClaimType == claim.ClaimType);
            throw new Exception("An Error occured while adding user claim");
        }

        public async Task<bool> DeleteUserClaim(int userClaimId, string userName)
        {
            var user = await _userManager.FindByEmailAsync(userName);
            var userClaim = user.Claims.FirstOrDefault(uc => uc.Id == userClaimId);
            user.Claims.Remove(userClaim);

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
    }
}