using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Ticket_Now.Repository.Dtos;
using Ticket_Now.Repository.Daos;

namespace Ticket_Now.Repository.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUserDto> _userManager;
        private ApplicationDbContext _ctx;

        public AuthRepository(UserManager<ApplicationUserDto> userManager, ApplicationDbContext ctx)
        {
            _ctx = ctx;
            _userManager = userManager;
        }

        public async Task<ApplicationUserDto> FindUser(string userName, string password)
        {
            var user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public async Task<IdentityResult> RegisterUser(ApplicationUserDto userModel)
        {
            var result = await _userManager.CreateAsync(userModel);

            return result;
        }
    }
}