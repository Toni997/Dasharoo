using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace DasharooAPI.HubConfig
{
    public class MyHub : Hub, IMyHub
    {
        public async Task NotifyOnConnect(string message)
        {
            await Clients.Caller.SendCoreAsync("Connected", new object[] { message });
        }

        public async Task SendNotification(object message)
        {
            await Clients.Others.SendCoreAsync("ReceiveNotification", new[] { message });
        }

        public async Task SendGenresNotification(object value)
        {
            await Clients.Others.SendCoreAsync("GenreNotification", new[] { value });
        }
    }
}
