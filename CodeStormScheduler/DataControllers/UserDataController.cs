using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeStormData.Data;
using CodeStormData.ViewModels;
using Microsoft.AspNet.Identity;

namespace CodeStormScheduler.DataControllers
{
    public class UserDataController : Controller
    {
        [HttpGet]
        public JsonResult GetCurrentUserProfileData()
        {
            string userid = User.Identity.GetUserId();
            UserData userData = new UserData();
            var user = userData.GetUserProfileData(userid);
            return Json(new {userid = user.Id,fname = user.FirstName,lname = user.LastName,imgurl = user.ImageUrl},JsonRequestBehavior.AllowGet);
        }
    }
}