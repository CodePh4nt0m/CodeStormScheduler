using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStormData.ViewModels
{
    public class UserViewModel
    {
        public string userid { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string imgurl { get; set; }
    }

    public class UserAutoCompleteViewModel
    {
        public string id { get; set; }
        public string text { get; set; }
        public string imgurl { get; set; }
    }
}
