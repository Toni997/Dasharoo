using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace DasharooAPI.HubConfig
{
    public interface IMyHub
    {
        Task NotifyOnConnect(string message);
        Task SendNotification(object message);
    }
}
