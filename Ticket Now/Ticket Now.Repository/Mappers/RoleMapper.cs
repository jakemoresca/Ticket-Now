using Microsoft.AspNet.Identity.EntityFramework;
using Ticket_Now.Repository.Models;

namespace Ticket_Now.Repository.Mappers
{
    public class RoleMapper : IRoleMapper
    {
        public IdentityRole ToDto(Role model)
        {
            return new IdentityRole
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public Role ToModel(IdentityRole dto)
        {
            return new Role
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }
    }
}
