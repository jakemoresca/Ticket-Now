﻿using System.Web.Http;

namespace Ticket_Now.Admin.Api.Controllers
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
