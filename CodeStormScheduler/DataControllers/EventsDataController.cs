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
                UserId = User.Identity.GetUserId()
            };
            EventsData eventsData = new EventsData();
            return eventsData.AddEvent(evnt);
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
    }
}