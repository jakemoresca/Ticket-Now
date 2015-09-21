using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Ticket_Now.Repository.Dtos;
using System;
using System.Collections.Generic;
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
            var user = new ApplicationUserDto
            {
                Email = userModel.Email,
                PasswordHash = userModel.PasswordHash,
                UserName = userModel.UserName,
                Hometown = userModel.Hometown,
                ZipCode = userModel.ZipCode
            };

            var result = await _userManager.CreateAsync(user);

            if(result.Succeeded)
                UpdateClaims(userModel, user);

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

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
                return user;
            throw new Exception("Error occured while updating user.");
        }

        public List<ApplicationUserDto> GetAllUser()
        {
            return _ctx.Users.ToList();
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