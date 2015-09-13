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
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserMapper _userMapper;

        public UserController(IAuthRepository authRepository, IUserMapper userMapper)
        {
            _authRepository = authRepository;
            _userMapper = userMapper;
        }

        [HttpGet]
        [Authorize]
        public List<UserModel> Get()
        {
            var users = _authRepository.GetAllUser().Select(u => _userMapper.ToModel(u));
            return users.ToList();
        }

        [HttpGet]
        [Authorize]
        public async Task<UserModel> Get(string name)
        {
            var userDto = await _authRepository.FindByName(name);
            return _userMapper.ToModel(userDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<UserModel> Post([FromBody]UserModel user)
        {
            var result = await _authRepository.RegisterUser(_userMapper.ToDto(user));
            if (!result.Succeeded) throw new Exception("An error occured while creating new user.");

            var newUser = await _authRepository.FindByName(user.UserName);
            return _userMapper.ToModel(newUser);
        }

        [HttpPut]
        [Authorize]
        public async Task<UserModel> Put([FromBody] UserModel user)
        {
            var updatedUserDto = await _authRepository.UpdateUser(_userMapper.ToDto(user));
            return _userMapper.ToModel(updatedUserDto);
        }

        [HttpDelete]
        [Authorize]
        public async Task<bool> Delete(string username)
        {
            return await _authRepository.DeleteUser(username);
        }
    }
}
