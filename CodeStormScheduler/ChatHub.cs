using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using CodeStormData.Data;
using Microsoft.AspNet.Identity;
using CodeStormScheduler.Models;

namespace CodeStormScheduler
{
    public class ChatHub : Hub
    {
        public void Send(string who, string message)
        {
            string name = Context.User.Identity.GetUserName();
            string userid = Context.User.Identity.GetUserId();
            UserData userData = new UserData();
            var user = userData.GetUserProfileData(userid);
            bool self = (userid == who ? true : false);
            if (userid != who)
                SaveMessage(message, userid, who);
            string img = user.ImageUrl == null ? "blank_photo.png" : user.ImageUrl;
            Clients.Group(who).addChatMessage(user.FirstName + " " + user.LastName, message, img, self,user.Id);
        }

        public override Task OnConnected()
        {
            string name = Context.User.Identity.GetUserId();
            Groups.Add(Context.ConnectionId, name);
            return base.OnConnected();
        }

        private void SaveMessage(string message, string sender, string receiver)
        {
            var msg = new CodeStormData.UserMessage()
            {
                Message = message,
                SenderId = sender,
                ReceiverId = receiver,
                Status = "Unread"
            };
            MessageData msgData = new MessageData();
            msgData.AddMessage(msg);
        }
    }
}