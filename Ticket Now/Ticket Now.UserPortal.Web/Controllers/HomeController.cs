﻿using System.Web.Mvc;

namespace Ticket_Now.UserPortal.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewSchedules()
        {
            return View();
        }

        public ActionResult Reservation()
        {
            return View();
        }
    }
}