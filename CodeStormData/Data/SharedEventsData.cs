using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStormData.ViewModels;
using EntityFramework.BulkInsert.Extensions;

namespace CodeStormData.Data
{
    public class SharedEventsData
    {
        public void AddSharedEvents(List<SharedEvent> eventlist)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                foreach (var se in eventlist)
                {
                    db.SharedEvents.Add(se);
                }
                db.SaveChanges();
            }
        }

        public void ClearEventSharedData(Int64 eventid)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                db.spClearSharedEvent(eventid);
            }
        }

        public void DeleteSharedEvents(List<SharedEvent> eventlist)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                foreach (var se in eventlist)
                {
                    var evnt =
                        db.SharedEvents.Where(e => e.EventId == se.EventId && e.UserId == se.UserId).FirstOrDefault();
                    db.SharedEvents.Remove(evnt);
                }
                db.SaveChanges();
            }
        }

        public List<SharedEvent> GetSharedUsers(Int64 eventid)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                return db.SharedEvents.Where(s => s.EventId == eventid && s.Status != "Reject").ToList();
            }
        }

        public NotificationViewModel GetNewestSharedEvent()
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                var shevent = (from se in db.SharedEvents
                               join e in db.Events on se.EventId equals e.Id
                               join u in db.UserProfiles on e.UserId equals u.Id
                               orderby se.ShraredEventId descending
                               select new NotificationViewModel()
                               {
                                   eventname = e.Text,
                                   owner = u.FirstName + " " + u.LastName,
                                   sharable = se.UserId
                               }).First();
                return shevent;
            }
        }

        public List<SharedUserViewModel> GetAcceptedEventUsers(Int64 eventid)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                return db.SharedEvents.Where(s => (s.Status == "Accept" || s.Status == "Pending") && s.EventId == eventid).Select(s => new SharedUserViewModel()
                {
                    userid = s.UserId
                }).ToList();
            }
        }

        public List<SharedEventNotificationViewModel> GetNotificationDetails(string userid)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                var result = from s in db.SharedEvents.AsEnumerable()
                             join e in db.Events.AsEnumerable() on s.EventId equals e.Id
                             join d in db.EventDetails.AsEnumerable() on e.Id equals d.Id
                             join u in db.UserProfiles.AsEnumerable() on e.UserId equals u.Id
                             where s.Status == "Pending" && s.UserId == userid
                             select new SharedEventNotificationViewModel()
                             {
                                 eventid = e.Id,
                                 eventname = e.Text,
                                 owner = u.FirstName + " " + u.LastName,
                                 location = d.Location,
                                 startdate = e.StartDate.ToString("yy-MM-dd"),
                                 enddate = e.EndDate.ToString("yy-MM-dd")
                             };
                return result.ToList();
            }
        }

        public dynamic UpdateSharedEventStatus(Int64 eventid,string userid,string status)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                var se = db.SharedEvents.Where(s => s.EventId == eventid && s.UserId == userid).FirstOrDefault();
                if (se != null)
                {
                    se.Status = status;
                    return db.SaveChanges();
                }
                return null;
            }
        }
    }
}
