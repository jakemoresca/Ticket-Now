using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ticket_Now.UserPortal.Api.Controllers
{
    public class TestController : ApiController
    {
        [Route("test/get")]
        public string Get()
        {
            return "test";
        }

        [Route("test/get/{test}")]
        public string Get(string test)
        {
            return test;
        }
    }
}
