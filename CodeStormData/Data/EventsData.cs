using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStormData.Data
{
    public class EventsData
    {
        public List<Event> GetAllEvents()
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                return db.Events.ToList();
            }
        }

        public List<Event> GetUserEvents(string userId)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                return db.Events.Where(e => e.UserId == userId).ToList();
            }
        }

        public Event GetEvent(int eventId)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                return db.Events.Find(eventId);
            }
        }

        public int AddEvent(Event evnt)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                db.Events.Add(evnt);
                db.SaveChanges();
                return evnt.EventId;
            }
        }

        public void UpdateEvent(Event evnt)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                var e = db.Events.Where(x => x.EventId == evnt.EventId).FirstOrDefault();
                if (e != null)
                {
                    e.StartDate = evnt.StartDate;
                    e.EndDate = evnt.EndDate;
                    e.Text = evnt.Text;
                    db.SaveChanges();
                }
            }
        }

        public void Delete(int eventId)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                var evnt = db.Events.Where(e => e.EventId == eventId).FirstOrDefault();
                if (evnt != null)
                {
                    db.Events.Remove(evnt);
                    db.SaveChanges();
                }
                    
            }
        }
    }
}
