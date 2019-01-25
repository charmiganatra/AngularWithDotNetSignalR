using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace bloodgrpsignal.hub
{
    public class Bloodgrouphub : Hub
    {
    public void dataupdateevent(string name, string message)
    {
        Clients.All.SendAsync("dataupdateevent", name, message);
    }

    public void Echo(string name, string message)
    {
        Clients.Client(Context.ConnectionId).SendAsync("echo", name, message + " (echo from server)");
    }
}
}
