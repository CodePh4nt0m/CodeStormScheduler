using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeStormData;
using CodeStormData.Data;
using CodeStormData.ViewModels;
using Microsoft.AspNet.Identity;

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
            var modeldata = events.Select(x => new CalenderEventViewModel()
            {
                id = x.Id,
                start_date = x.StartDate.ToString("MM/dd/yyyy HH:mm"),
                end_date = x.EndDate.ToString("MM/dd/yyyy HH:mm"),
                text = x.Text,
                rec_type = x.RecType,
                event_length = x.EventLength,
                event_pid = x.EventPid,
                color = x.Color
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
                UserId = User.Identity.GetUserId()
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
            return Json(ed, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void SaveEventDetails(EventDetailViewModel model)
        {
            Event evnt = new Event()
            {
                Id = model.id,
                Text = model.text,
                Color = model.color
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
        }
    }
}