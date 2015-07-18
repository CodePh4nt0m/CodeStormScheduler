using System;

namespace CodeStormData.ViewModels
{
    public class NotificationViewModel
    {
        public string eventname { get; set; }
        public string owner { get; set; }
        public string sharable { get; set; }
    }

    public class MessageNotificationViewModel
    {
        public string message { get; set; }
        public string sender { get; set; }
        public string receiver { get; set; }
    }

    public class SharedEventNotificationViewModel
    {
        public Int64 eventid { get; set; }
        public string eventname { get; set; }
        public string owner { get; set; }
        public string location { get; set; }
        public string startdate { get; set; }
        public string enddate { get; set; }
    }
}