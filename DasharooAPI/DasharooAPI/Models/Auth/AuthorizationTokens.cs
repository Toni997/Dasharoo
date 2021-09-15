using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DasharooAPI.Models.Auth
{
    public class AuthorizationTokens
    {
        public TokenResource AccessToken { get; set; }
        public TokenResource RefreshToken { get; set; }
    }
}
