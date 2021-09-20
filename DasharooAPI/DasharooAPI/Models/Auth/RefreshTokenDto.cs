using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DasharooAPI.Models.Auth
{
    public class RefreshTokenDto
    {
        public string UserId { get; set; }
        public string Token { get; set; }
    }
}
