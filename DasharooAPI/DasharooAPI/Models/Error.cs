using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DasharooAPI.Models
{
    public class Error : ResponseDetails
    {
        public Error(int statusCode, string message)
        {
            StatusCode = statusCode;
            Value = message;
        }
    }

    public class Success : ResponseDetails
    {
        public Success(int statusCode, string message)
        {
            StatusCode = statusCode;
            Value = message;
        }
    }
}
