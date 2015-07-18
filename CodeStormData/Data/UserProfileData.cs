using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStormData.ViewModels;

namespace CodeStormData.Data
{
    public class UserProfileData
    {
        public void UpdateUserPhoto(string userid,string imgurl)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                var user = db.UserProfiles.Where(u => u.Id == userid).FirstOrDefault();
                if (user != null)
                {
                    user.ImageUrl = imgurl;
                    db.SaveChanges();
                }
            }
        }

        public UserProfile GetUserProfile(string userid)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                return db.UserProfiles.Where(u => u.Id == userid).FirstOrDefault();
            }
        }

        public dynamic UpdateGeneralDetails(UserProfile userProfile)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                var user =  db.UserProfiles.Where(u => u.Id == userProfile.Id).FirstOrDefault();
                if (user != null)
                {
                    user.FirstName = userProfile.FirstName;
                    user.LastName = userProfile.LastName;
                    user.Gender = userProfile.Gender;
                    user.DOB = userProfile.DOB;
                    user.Location = userProfile.Location;
                    user.Mobile = userProfile.Mobile;
                    user.Profession = userProfile.Profession;
                    return db.SaveChanges();
                }
                return null;
            }
        }

        public dynamic UpdateSocailDetails(UserProfile userProfile)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                var user = db.UserProfiles.Where(u => u.Id == userProfile.Id).FirstOrDefault();
                if (user != null)
                {
                    user.AboutMe = userProfile.AboutMe;
                    user.Interests = userProfile.Interests;
                    user.Twitter = userProfile.Twitter;
                    user.Facebook = userProfile.Facebook;
                    return db.SaveChanges();
                }
                return null;
            }
        }
    }
}
