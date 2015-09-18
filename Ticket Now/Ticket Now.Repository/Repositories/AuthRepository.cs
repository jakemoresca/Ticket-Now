using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Ticket_Now.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
                return user;
            throw new Exception("Error occured while updating user.");
        }

        public List<ApplicationUserDto> GetAllUser()
        {
            return _ctx.Users.ToList();
        }
    }
}