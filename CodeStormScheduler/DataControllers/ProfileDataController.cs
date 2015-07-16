using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeStormData.Data;
using CodeStormData.ViewModels;
using CodeStormScheduler.ViewModels;
using Microsoft.AspNet.Identity;

namespace CodeStormScheduler.DataControllers
{
    public class ProfileDataController : Controller
    {
        [HttpPost]
        public string ChangeAvatar(FileUploadViewModel fileUpload)
        {
            string name = Guid.NewGuid().ToString() + Path.GetExtension(fileUpload.Attachment.FileName);
            string nameAndLocation = Path.Combine(Server.MapPath("~/ImageBase/Users"), name);
            fileUpload.Attachment.SaveAs(nameAndLocation);
            string userid = User.Identity.GetUserId();
            UserProfileData userProfileData = new UserProfileData();
            userProfileData.UpdateUserPhoto(userid,name);
            return name;
        }

        [HttpGet]
        public JsonResult GetGeneralDetails()
        {
            UserProfileData userProfileData = new UserProfileData();
            var userprofile = userProfileData.GetUserProfile(User.Identity.GetUserId());
            var model = new UserGeneralDetailsViewModel()
            {
                fname = userprofile.FirstName,
                lname = userprofile.LastName,
                gender = (userprofile.Gender == "Male") ? true : false,
                location = userprofile.Location,
                mobile = userprofile.Mobile,
                profession = userprofile.Profession
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}