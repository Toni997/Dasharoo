using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DasharooAPI.Models.Auth
{
    public class TokenResource
    {
        public string Token { get; set; }
        public long Expiry { get; set; }
    }
}
