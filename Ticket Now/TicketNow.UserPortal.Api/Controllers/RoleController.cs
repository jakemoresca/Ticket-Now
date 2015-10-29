using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Ticket_Now.Repository.Mappers;
using Ticket_Now.Repository.Models;
using Ticket_Now.Repository.Repositories;

namespace TicketNow.UserPortal.Api.Controllers
{
    [RoutePrefix("Role")]
    public class RoleController : ApiController
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRoleMapper _roleMapper;

        public RoleController(IRoleRepository roleRepository, IRoleMapper roleMapper)
        {
            _roleRepository = roleRepository;
            _roleMapper = roleMapper;
        }

        [HttpGet]
        [Authorize]
        public List<Role> Get()
        {
            var roles = _roleRepository.GetAll().Select(u => _roleMapper.ToModel(u));
            return roles.ToList();
        }
    }
}
