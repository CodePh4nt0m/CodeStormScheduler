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

        public List<SharedEvent> GetSharedUsers(Int64 eventid)
        {
            using (CodeStormDBEntities db = new CodeStormDBEntities())
            {
                return db.SharedEvents.Where(s => s.EventId == eventid).ToList();
            }
        }
    }
}
