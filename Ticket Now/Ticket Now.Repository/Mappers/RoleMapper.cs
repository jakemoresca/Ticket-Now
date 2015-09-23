using Ticket_Now.Repository.Dtos;
using Ticket_Now.Repository.Models;

namespace Ticket_Now.Repository.Mappers
{
    public class RoleMapper : IRoleMapper
    {
        public RoleDto ToDto(Role model)
        {
            return new RoleDto
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public Role ToModel(RoleDto dto)
        {
            return new Role
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
    }
}
