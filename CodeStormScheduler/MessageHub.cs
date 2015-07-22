using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace CodeStormScheduler
{
    public class MessageHub : Hub
    {
        public override Task OnConnected()
        {
            string name = Context.User.Identity.GetUserId();
            Groups.Add(Context.ConnectionId, name);
            return base.OnConnected();
        }
    }
}