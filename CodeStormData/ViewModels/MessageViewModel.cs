using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CodeStormData.ViewModels
{
    public class MessageViewModel
    {
        public int messageid { get; set; }
        public string message { get; set; }
        public string sender { get; set; }
        public string receiver { get; set; }

    }

    public class ConversationListViewModel
    {
        public string convid { get; set; }
        public string fullname { get; set; }
        public string message { get; set; }
        public string imgurl { get; set; }
        public string time { get; set; }
    }

    public class ConversationViewModel
    {
        public int messageid { get; set; }
        public string fullname { get; set; }
        public string message { get; set; }
        public string imgurl { get; set; }
        public string time { get; set; }
        public bool? self { get; set; }
    }
}
