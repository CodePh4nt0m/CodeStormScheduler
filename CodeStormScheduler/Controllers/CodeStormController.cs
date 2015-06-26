using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeStormScheduler.Controllers
{
    public class CodeStormController : Controller
    {
        // GET: CodeStorm
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calender()
        {
            return View();
        }
    }
}