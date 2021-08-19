using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DasharooAPI.Models
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);

        public static Error Create(int statusCode, string message) =>
            new()
            {
                StatusCode = statusCode,
                Message = message
            };
    }
}
