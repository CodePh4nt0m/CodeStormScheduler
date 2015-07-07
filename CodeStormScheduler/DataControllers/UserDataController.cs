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

        [HttpGet]
        public JsonResult GetAutoCompleteUserList()
        {
            UserData userData = new UserData();
            var userlist = userData.GetUsersList().OrderBy(u => u.FirstName).ThenBy(u => u.LastName).Select(u => new UserAutoCompleteViewModel()
            {
                id = u.Id,
                text = u.FirstName + " " + u.LastName,
                imgurl = u.ImageUrl == null ? "blank_photo.png" : u.ImageUrl
            }).ToList();
            userlist.Remove(userlist.Where(u => u.id == User.Identity.GetUserId()).First());
            return Json(userlist, JsonRequestBehavior.AllowGet);
        }
    }
}