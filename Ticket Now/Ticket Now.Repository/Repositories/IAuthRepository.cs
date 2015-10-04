using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ticket_Now.Repository.Dtos;

namespace Ticket_Now.Repository.Repositories
{
    public interface IAuthRepository
    {
        Task<IdentityResult> RegisterUser(ApplicationUserDto user);
        Task<ApplicationUserDto> FindUser(string userName, string password);
        Task<ApplicationUserDto> FindById(string id);
        Task<ApplicationUserDto> FindByName(string name);
        Task<bool> DeleteUser(string id);
        Task<ApplicationUserDto> UpdateUser(ApplicationUserDto user);
        List<ApplicationUserDto> GetAllUser();
    }
}
