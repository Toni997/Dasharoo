using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DasharooAPI.Models
{
    public abstract class ResponseDetails
    {
        public bool Succeeded { get; set; }
        public int StatusCode { get; set; }
        public object Value { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }

    public class Error : ResponseDetails
    {
        public Error(int statusCode, object value)
        {
            Succeeded = false;
            StatusCode = statusCode;
            Value = value;
        }
    }

    public class Success : ResponseDetails
    {
        public Success(int statusCode, object value)
        {
            Succeeded = true;
            StatusCode = statusCode;
            Value = value;
        }
    }
}
