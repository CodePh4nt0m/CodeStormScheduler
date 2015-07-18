using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeStormData;
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
                gender = userprofile.Gender,
                dob = userprofile.DOB.ToString("MM/dd/yyyy"),
                location = userprofile.Location,
                mobile = userprofile.Mobile,
                profession = userprofile.Profession
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetUserProfileDetails()
        {
            UserProfileData userProfileData = new UserProfileData();
            var u = userProfileData.GetUserProfile(User.Identity.GetUserId());
            var model = new UserProfileViewModel()
            {
                fullname = u.FirstName + " " + u.LastName,
                gender = u.Gender,
                dob = u.DOB.ToString("dd/MM/yyyy"),
                location = u.Location,
                mobile = u.Mobile,
                profession = u.Profession,
                aboutme = u.AboutMe,
                interests = u.Interests,
                twitter = u.Twitter,
                facebook = u.Facebook
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetUserPublicProfileDetails(string id)
        {
            UserProfileData userProfileData = new UserProfileData();
            var u = userProfileData.GetUserProfile(id);
            var model = new UserPublicProfileViewModel()
            {
                userid = u.Id,
                fullname = u.FirstName + " " + u.LastName,
                fname = u.FirstName,
                photo = u.ImageUrl == null ? "blank_photo.png" : u.ImageUrl,
                gender = u.Gender,
                dob = u.DOB.ToString("dd/MM/yyyy"),
                location = u.Location,
                mobile = u.Mobile,
                profession = u.Profession,
                aboutme = u.AboutMe,
                interests = u.Interests,
                twitter = u.Twitter,
                facebook = u.Facebook
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public dynamic SavGeneralDetails(UserGeneralDetailsViewModel model)
        {
            UserProfileData userProfileData = new UserProfileData();
            var userprofile = new UserProfile()
            {
                Id = User.Identity.GetUserId(),
                FirstName = model.fname,
                LastName = model.lname,
                Gender = model.gender,
                DOB = Convert.ToDateTime(model.dob),
                Location = model.location,
                Mobile = model.mobile,
                Profession = model.profession
            };
            return userProfileData.UpdateGeneralDetails(userprofile);
        }

        [HttpGet]
        public JsonResult GetUserSocialDetails()
        {
            UserProfileData userProfileData = new UserProfileData();
            var u = userProfileData.GetUserProfile(User.Identity.GetUserId());
            var model = new UserSocialViewModel()
            {
                aboutme = u.AboutMe,
                interests = u.Interests,
                twitter = u.Twitter,
                facebook = u.Facebook
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public dynamic SaveSocialDetails(UserSocialViewModel model)
        {
            UserProfileData userProfileData = new UserProfileData();
            var userprofile = new UserProfile()
            {
                Id = User.Identity.GetUserId(),
                AboutMe = model.aboutme,
                Interests = model.interests,
                Twitter = model.twitter,
                Facebook = model.facebook
            };
            return userProfileData.UpdateSocailDetails(userprofile);
        }
    }
}