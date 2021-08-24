using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DasharooAPI.Models
{
    public abstract class ResponseDetails
    {
        public int StatusCode { get; set; }
        public string Value { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
