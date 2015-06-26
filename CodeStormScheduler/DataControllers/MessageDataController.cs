using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeStormData.Data;
using CodeStormData.ViewModels;

namespace CodeStormScheduler.DataControllers
{
    public class MessageDataController : Controller
    {
        // GET: MessageData
        public ActionResult Index()
        {
            return View();
        }
    }
}