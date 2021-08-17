using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Models;

namespace DasharooAPI.Services
{
    public interface IMessageService
    {
        Task SendAsync(MessageToSend message);
    }
}
