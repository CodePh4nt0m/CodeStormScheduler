using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
