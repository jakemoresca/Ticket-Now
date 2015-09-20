using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Ticket_Now.Authentication.Helper;
using Ticket_Now.Repository.Mappers;
using Ticket_Now.Repository.Models;
using Ticket_Now.Repository.Repositories;

namespace Ticket_Now.Authentication.Controllers
{
    [RoutePrefix("api/Me")]
    public class MeController : ApiController
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserMapper _userMapper;

        public MeController(IAuthRepository authRepository, IUserMapper userMapper)
        {
            _authRepository = authRepository;
            _userMapper = userMapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<UserModel> Get()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<System.Security.Claims.Claim> claims = identity.Claims;

            var user = await _authRepository.FindByName(IdentityHelper.GetUserNameFromClaims(claims));
            return _userMapper.ToModel(user);
        }
    }
}
