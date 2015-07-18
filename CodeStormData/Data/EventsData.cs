using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CodeStormData.ViewModels;

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

        public List<Event> GetUserSharedEvents(string userId)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                var events = from e in db.Events
                    join s in db.SharedEvents on e.Id equals s.EventId
                    where s.UserId == userId && s.Status=="Accept"
                    select e;
                return events.ToList();
            }
        }

        public Event GetEvent(Int64 eventId)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                return db.Events.Where(e => e.Id == eventId).FirstOrDefault();
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
                var e = db.Events.Where(x => x.Id == evnt.Id).FirstOrDefault();
                if (e != null)
                {
                    e.StartDate = evnt.StartDate;
                    e.EndDate = evnt.EndDate;
                    e.Text = evnt.Text;
                    e.RecType = evnt.RecType;
                    e.EventLength = evnt.EventLength;
                    e.EventPid = evnt.EventPid;
                    db.SaveChanges();
                }
            }
        }

        public void UpdateEventDtl(Event evnt)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                var e = db.Events.Where(x => x.Id == evnt.Id).FirstOrDefault();
                if (e != null)
                {
                    e.Text = evnt.Text;
                    e.Color = evnt.Color;
                    e.Shared = evnt.Shared;
                    db.SaveChanges();
                }
            }
        }

        public void Delete(Int64 eventId)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                var evnt = db.Events.Where(e => e.Id == eventId).FirstOrDefault();
                if (evnt != null)
                {
                    db.Events.Remove(evnt);
                    db.SaveChanges();
                }
                    
            }
        }

        public EventDetailViewModel GetEventDetails(Int64 id)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                var evnt = from e in db.Events.AsEnumerable()
                    join ed in db.EventDetails.AsEnumerable() on e.Id equals ed.Id
                    where e.Id == id
                    select new EventDetailViewModel()
                    {
                        text = e.Text,
                        description = ed.Description,
                        start_date = e.StartDate.ToString("MM/dd/yyyy HH:mm"),
                        end_date = e.EndDate.ToString("MM/dd/yyyy HH:mm"),
                        color = e.Color,
                        location = ed.Location,
                        longitude = ed.Longitude,
                        latitude = ed.Latitude,
                        shared = e.Shared
                    };

                return evnt.FirstOrDefault();

            }
        }
    }
}
