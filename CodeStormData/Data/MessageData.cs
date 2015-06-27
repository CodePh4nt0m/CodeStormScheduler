using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStormData.ViewModels;

namespace CodeStormData.Data
{
    public class MessageData
    {
        public List<spGetConversationList_Result> GetConversationList(string userid)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                var convlist = db.spGetConversationList(userid);
                return convlist.ToList();
            }
        }

        public List<spGetConversation_Result> GetConversation(string userid,string convid)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                var convsation = db.spGetConversation(convid, userid);
                return convsation.ToList();
            }
        }

        public int AddMessage(UserMessage msg)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                db.UserMessages.Add(msg);
                db.SaveChanges();
                return msg.MessageId;
            }
        }
    }
}
