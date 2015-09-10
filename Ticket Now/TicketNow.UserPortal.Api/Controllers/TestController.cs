using System.Web.Http;

namespace TicketNow.UserPortal.Api.Controllers
{
    public class TestController : ApiController
    {
        [Route("test/get")]
        public string Get()
        {
            return "test";
        }

        [Route("test/get/{test}")]
        [Authorize]
        public string Get(string test)
        {
            return test;
        }
    }
}
