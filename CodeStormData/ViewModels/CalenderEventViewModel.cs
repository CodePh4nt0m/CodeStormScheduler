using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStormData.ViewModels
{
    public class CalenderEventViewModel
    {
        public Int64 id { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string text { get; set; }
        public string rec_type { get; set; }
        public Int64 event_length { get; set; }
        public Int64 event_pid { get; set; }
        public string color { get; set; }
        public string userid { get; set; }
    }

    public class EventDetailViewModel
    {
        public Int64 id { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string text { get; set; }
        public string rec_type { get; set; }
        public Int64 event_length { get; set; }
        public Int64 event_pid { get; set; }
        public string color { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public bool shared { get; set; }
        public List<SharedUserViewModel> sharedlist { get; set; }
    }

    public class SharedUserViewModel
    {
        public string userid { get; set; }
    }

}
