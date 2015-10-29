using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Ticket_Now.Repository.Mappers;
using Ticket_Now.Repository.Models;
using Ticket_Now.Repository.Repositories;

namespace TicketNow.UserPortal.Api.Controllers
{
    [RoutePrefix("User")]
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

    }
}
