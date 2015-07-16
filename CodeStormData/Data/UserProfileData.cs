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
    }
}
