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
            return RedirectToAction("codestorm", "Home");
        }

        public ActionResult codestorm()
        {
            return View();
        }
    }
}