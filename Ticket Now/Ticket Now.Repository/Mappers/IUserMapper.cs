using Ticket_Now.Repository.Dtos;
using Ticket_Now.Repository.Models;

namespace Ticket_Now.Repository.Mappers
{
    public interface IUserMapper
    {
        ApplicationUserDto ToDto(UserModel model);
        UserModel ToModel(ApplicationUserDto dto);
    }
}
