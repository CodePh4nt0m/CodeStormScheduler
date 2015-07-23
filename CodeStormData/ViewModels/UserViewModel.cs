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

    public class UserProfileViewModel
    {
        public string userid { get; set; }
        public string fullname { get; set; }
        public string gender { get; set; }
        public string dob { get; set; }
        public string location { get; set; }
        public string mobile { get; set; }
        public string profession { get; set; }

        public string aboutme { get; set; }
        public string interests { get; set; }
        public string twitter { get; set; }
        public string facebook { get; set; }
        public string email { get; set; }

    }

    public class UserPublicProfileViewModel
    {
        public string userid { get; set; }
        public string fname { get; set; }
        public string photo { get; set; }
        public string fullname { get; set; }
        public string gender { get; set; }
        public string dob { get; set; }
        public string location { get; set; }
        public string mobile { get; set; }
        public string profession { get; set; }

        public string aboutme { get; set; }
        public string interests { get; set; }
        public string twitter { get; set; }
        public string facebook { get; set; }
        public string email { get; set; }

    }

    public class UserProfileEditViewModel
    {
        public string userid { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string gender { get; set; }
        public string dob { get; set; }
        public string location { get; set; }
        public string mobile { get; set; }
        public string profession { get; set; }

        public string aboutme { get; set; }
        public string interests { get; set; }
        public string twitter { get; set; }
        public string facebook { get; set; }

    }

    public class UserGeneralDetailsViewModel
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string gender { get; set; }
        public string dob { get; set; }
        public string location { get; set; }
        public string mobile { get; set; }
        public string profession { get; set; }
    }

    public class UserSocialViewModel
    {
        public string aboutme { get; set; }
        public string interests { get; set; }
        public string twitter { get; set; }
        public string facebook { get; set; }
    }
}
