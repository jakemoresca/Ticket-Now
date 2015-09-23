using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Ticket_Now.Repository.Dtos;

namespace Ticket_Now.Repository.Daos
{
    public class ApplicationRoleManager : RoleManager<RoleDto>
    {
        public ApplicationRoleManager(IRoleStore<RoleDto> store)
        : base(store)
        {
            RoleValidator = new RoleValidator<RoleDto>(this)
            {
                
            };
        }
    }
}
