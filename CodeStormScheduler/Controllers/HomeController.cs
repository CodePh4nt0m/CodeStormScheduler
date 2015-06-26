using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeStormScheduler.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return View("Landing");
            return View();
            //return RedirectToAction("calender", "CodeStorm");
        }

        public ActionResult codestorm()
        {
            return View();
        }
    }
}