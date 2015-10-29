using System.Web.Mvc;

namespace TicketNow.UserPortal.Api.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}