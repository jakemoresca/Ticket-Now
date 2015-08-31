using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ticket_Now.UserPortal.Api.Controllers;

namespace Ticket_Now.Tests.Controllers
{
    [TestClass]
    public class TestControllerTest
    {
        [TestMethod]
        public void Should_Return_String_On_Get()
        {
            TestController controller = new TestController();

            var result = controller.Get("Test Message");
            Assert.IsInstanceOfType(result, typeof(string));
            Assert.AreSame(result, "Test Message");
        }
    }
}
