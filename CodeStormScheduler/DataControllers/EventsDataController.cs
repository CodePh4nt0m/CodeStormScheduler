using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeStormData;
using CodeStormData.Data;
using CodeStormData.ViewModels;
using Microsoft.AspNet.Identity;
using EntityFramework.BulkInsert.Extensions;

namespace CodeStormScheduler.DataControllers
{
    public class EventsDataController : Controller
    {

        [HttpGet]
        public JsonResult GetEvents()
        {
            string userid = User.Identity.GetUserId();
            EventsData eventsData = new EventsData();
            var events = eventsData.GetUserEvents(userid);
            var sharedevents = eventsData.GetUserSharedEvents(userid);
            events.AddRange(sharedevents);
            var modeldata = events.Select(x => new CalenderEventViewModel()
            {
                id = x.Id,
                start_date = x.StartDate.ToString("MM/dd/yyyy HH:mm"),
                end_date = x.EndDate.ToString("MM/dd/yyyy HH:mm"),
                text = x.Text,
                rec_type = x.RecType,
                event_length = x.EventLength,
                event_pid = x.EventPid,
                color = x.Color,
                userid = x.UserId
            }).ToList();
            return Json(modeldata, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public int AddEvent(CalenderEventViewModel model)
        {
            Event evnt = new Event()
            {
                Id = model.id,
                StartDate = Convert.ToDateTime(model.start_date),
                EndDate = Convert.ToDateTime(model.end_date),
                Text = model.text,
                RecType = model.rec_type,
                EventLength = model.event_length,
                EventPid = model.event_pid,
                Color = "#5484ed",
                UserId = User.Identity.GetUserId(),
                Shared = false
                
            };
            EventsData eventsData = new EventsData();
            var res = eventsData.AddEvent(evnt);

            EventDetail ed = new EventDetail()
            {
                Id = model.id
            };
            EventDetailData eventDetailData = new EventDetailData();
            eventDetailData.AddEventDetail(ed);
            return res;
        }

        [HttpPost]
        public void UpdateEvent(CalenderEventViewModel model)
        {
            Event evnt = new Event()
            {
                Id = model.id,
                StartDate = Convert.ToDateTime(model.start_date),
                EndDate = Convert.ToDateTime(model.end_date),
                Text = model.text,
                RecType = model.rec_type == "none" ? null : model.rec_type,
                EventLength = model.event_length,
                EventPid = model.event_pid,
                UserId = User.Identity.GetUserId()
            };
            EventsData eventsData = new EventsData();
            eventsData.UpdateEvent(evnt);
        }

        [HttpPost]
        public void RemoveEvent(Int64 eventid)
        {
            EventsData eventsData = new EventsData();
            eventsData.Delete(eventid);
        }

        [HttpGet]
        public JsonResult GetEventDetails(Int64 id)
        {
            EventsData eventsData = new EventsData();
            var ed = eventsData.GetEventDetails(id);

            SharedEventsData sharedEventsData = new SharedEventsData();
            var sharedusers = sharedEventsData.GetSharedUsers(id);
            var usermodel = sharedusers.Select(x => new SharedUserViewModel()
            {
                userid = x.UserId
            }).ToList();
            ed.sharedlist = usermodel;
            return Json(ed, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void SaveEventDetails(EventDetailViewModel model)
        {
            Event evnt = new Event()
            {
                Id = model.id,
                Text = model.text,
                Color = model.color,
                Shared = model.shared
            };
            EventDetail eventDetail = new EventDetail()
            {
                Id = model.id,
                Description = model.description,
                Location = model.location,
                Latitude = model.latitude,
                Longitude = model.longitude
            };

            EventsData eventsData = new EventsData();
            eventsData.UpdateEventDtl(evnt);

            EventDetailData eventDetailData = new EventDetailData();
            eventDetailData.UdateEventDetail(eventDetail);

            SharedEventsData sharedEventsData = new SharedEventsData();
            var modellist = model.sharedlist;
            var acceptlist = sharedEventsData.GetAcceptedEventUsers(model.id);
            var insertlist = modellist.Where(x => !acceptlist.Select(y=> y.userid).Contains(x.userid)).ToList();
            var deletelist = acceptlist.Where(x => !modellist.Select(y => y.userid).Contains(x.userid)).ToList();

            if (model.shared)
            {
                if (insertlist != null)
                {
                    string userid = User.Identity.GetUserId();
                    //sharedEventsData.ClearEventSharedData(model.id);
                    List<SharedEvent> insertEvents = new List<SharedEvent>();

                    foreach (var e in insertlist)
                    {
                        var se = new SharedEvent()
                        {
                            UserId = e.userid,
                            EventId = model.id,
                            Status = "Pending"
                        };
                        insertEvents.Add(se);
                    }
                    sharedEventsData.AddSharedEvents(insertEvents);

                    List<SharedEvent> deleteEvents = new List<SharedEvent>();
                    foreach (var e in deletelist)
                    {
                        var se = new SharedEvent()
                        {
                            UserId = e.userid,
                            EventId = model.id,
                            Status = "Delete"
                        };
                        deleteEvents.Add(se);
                    }
                    sharedEventsData.DeleteSharedEvents(deleteEvents);
                }
            }
            else
            {
                sharedEventsData.ClearEventSharedData(model.id);
            }
        }

        [HttpGet]
        public JsonResult GetPendingSharedEvents()
        {
            SharedEventsData sharedEventsData = new SharedEventsData();
            var model = sharedEventsData.GetNotificationDetails(User.Identity.GetUserId());
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public dynamic AcceptEvent(Int64 eventid)
        {
            SharedEventsData sharedEventsData = new SharedEventsData();
            return sharedEventsData.UpdateSharedEventStatus(eventid, User.Identity.GetUserId(), "Accept");
        }

        [HttpPost]
        public dynamic RejectEvent(Int64 eventid)
        {
            SharedEventsData sharedEventsData = new SharedEventsData();
            return sharedEventsData.UpdateSharedEventStatus(eventid, User.Identity.GetUserId(), "Reject");
        }
    }
}