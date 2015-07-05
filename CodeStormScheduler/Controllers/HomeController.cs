using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeStormScheduler.Models;
using Microsoft.AspNet.Identity;

namespace CodeStormScheduler.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return View("Landing");
            using (CodeStormDbContext db = new CodeStormDbContext())
            {
                var user = db.Users.Find(User.Identity.GetUserId());
                if (!user.EmailConfirmed)
                    return View("Landing");
            }
            
            return View();
            //return RedirectToAction("calender", "CodeStorm");
        }

        public ActionResult codestorm()
        {
            return View();
        }
    }
}