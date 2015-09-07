using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Web.Http;
using Ticket_Now.Repository.Dtos;
using Ticket_Now.Repository.Mappers;
using Ticket_Now.Repository.Models;
using Ticket_Now.Repository.Repositories;

namespace Ticket_Now.Authentication.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly IAuthRepository _authRepository;
        private readonly IUserMapper _userMapper;

        public AccountController(IAuthRepository authRepository, IUserMapper userMapper)
        {
            _authRepository = authRepository;
            _userMapper = userMapper;
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userDto = _userMapper.ToDto(userModel);
            var result = await _authRepository.RegisterUser(userDto);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        [AllowAnonymous]
        [Route("Login")]
        public async Task<IHttpActionResult> Login(UserModel userModel)
        {
            if(ModelState.IsValid)
            {
                var user = await _authRepository.FindUser(userModel.UserName, userModel.Password);

                return Ok(user);
            }

            return BadRequest("Invalid username and password");
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
