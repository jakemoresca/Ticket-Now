using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Ticket_Now.Repository.Mappers;
using Ticket_Now.Repository.Models;
using Ticket_Now.Repository.Repositories;

namespace Ticket_Now.Admin.Api.Controllers
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

        [HttpGet]
        [Authorize]
        public async Task<Role> Get(string name)
        {
            var roleDto = await _roleRepository.FindByName(name);
            return _roleMapper.ToModel(roleDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<Role> Post([FromBody]Role role)
        {
            var result = await _roleRepository.AddRole(_roleMapper.ToDto(role));
            if (!result.Succeeded) throw new Exception("An error occured while creating new user.");

            var newRole = await _roleRepository.FindByName(role.Name);
            return _roleMapper.ToModel(newRole);
        }

        [HttpPut]
        [Authorize]
        [Route("{Id}")]
        public async Task<Role> Put([FromBody] Role role, string id)
        {
            var updatedRoleDto = await _roleRepository.UpdateRole(_roleMapper.ToDto(role));
            return _roleMapper.ToModel(updatedRoleDto);
        }

        [HttpDelete]
        [Authorize]
        [Route("{Id}")]
        public async Task<bool> Delete(string id)
        {
            return await _roleRepository.DeleteRole(id);
        }
    }
}
