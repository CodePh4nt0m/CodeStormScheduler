using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStormData.ViewModels;

namespace CodeStormData.Data
{
    public class UserData
    {
        public AspNetUser GetUserMasterData(string userid)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                return db.AspNetUsers.Find(userid);
            }
        }

        public UserProfile GetUserProfileData(string userid)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                return db.UserProfiles.Where(p => p.Id == userid).FirstOrDefault();
            }
        }

        public List<UserProfile> GetUsersList()
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                return db.UserProfiles.ToList();
            }
        }

        public UserProfileEditViewModel GetUserEditDetails(string userid)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                var user = from u in db.AspNetUsers.AsEnumerable()
                    join p in db.UserProfiles.AsEnumerable() on u.Id equals p.Id
                    where p.Id == userid
                    select new UserProfileEditViewModel()
                    {
                        userid = u.Id,
                        fname = p.FirstName,
                        lname = p.LastName,
                        dob = p.DOB.ToString(),
                        gender = p.Gender,
                        location = p.Location,
                        mobile = p.Mobile,
                        profession = p.Profession,
                        aboutme = p.AboutMe,
                        twitter = p.Twitter,
                        facebook = p.Facebook,
                        interests = p.Interests
                    };
                return user.FirstOrDefault();
            }
        }
    }
}
