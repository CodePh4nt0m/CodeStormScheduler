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

        public int ChangeMessageStatus(string receiverid,string senderid,string status)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                return db.spChangeMessageStatus(receiverid, senderid, status);
            }
        }

        public MessageNotificationViewModel GetLatestMessage()
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                var msg = (from m in db.UserMessages
                    join s in db.UserProfiles on m.SenderId equals s.Id
                    where m.Status == "Unread"
                    orderby m.MessageId descending
                    select new MessageNotificationViewModel()
                    {
                        receiver = m.ReceiverId,
                        message = m.Message,
                        sender = s.FirstName + " " + s.LastName
                    }).First();
                return msg;
            }
        }

        public int GetUserUnreadMessageCount(string userid)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                var count = db.spGetUserMessageCount(userid).First();
                return Convert.ToInt32(count.Value);
            }
        }

    }
}
