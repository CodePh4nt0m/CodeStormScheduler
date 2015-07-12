using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeStormData.Data;

namespace CodeStormScheduler.Controllers
{
    public class CalenderController : Controller
    {
        // GET: Calender
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Event(Int64 id)
        {
            EventsData eventsData = new EventsData();
            var evnt = eventsData.GetEvent(id);
            ViewBag.Name = evnt.Text;
            return View();
        }
    }
}