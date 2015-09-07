using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using Ticket_Now.Repository.Dtos;

namespace Ticket_Now.Repository.Repositories
{
    public interface IAuthRepository
    {
        Task<IdentityResult> RegisterUser(ApplicationUserDto user);
        Task<ApplicationUserDto> FindUser(string userName, string password);
    }
}
