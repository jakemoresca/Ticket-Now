using Microsoft.AspNet.Identity.EntityFramework;
using Ticket_Now.Repository.Models;

namespace Ticket_Now.Repository.Mappers
{
    public interface IRoleMapper
    {
        IdentityRole ToDto(Role model);
        Role ToModel(IdentityRole dto);
    }
}