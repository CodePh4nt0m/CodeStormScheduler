using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStormData.ViewModels
{
    public class CalenderEventViewModel
    {
        public int id { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string text { get; set; }
    }
}
