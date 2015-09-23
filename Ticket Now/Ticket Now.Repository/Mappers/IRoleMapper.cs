using Ticket_Now.Repository.Dtos;
using Ticket_Now.Repository.Models;

namespace Ticket_Now.Repository.Mappers
{
    public interface IRoleMapper
    {
        RoleDto ToDto(Role model);
        Role ToModel(RoleDto dto);
    }
}