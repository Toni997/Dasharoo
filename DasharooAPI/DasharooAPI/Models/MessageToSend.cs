using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DasharooAPI.Models
{
    public class MessageToSend
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Destination { get; set; }
    }
}
