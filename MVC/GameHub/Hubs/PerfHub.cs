using Microsoft.AspNet.SignalR;
using System;

namespace GameHub.Hubs
{
    public class PerfHub : Hub
    {
        public void Send(string message)
        {
            Clients.All.newMessage(
                DateTime.Now.ToString("HH:mm:ss") + " | " +  Context.User.Identity.Name + " : " + message );
        }
    }
}