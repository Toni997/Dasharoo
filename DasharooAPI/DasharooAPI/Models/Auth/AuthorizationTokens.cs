﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DasharooAPI.Models.Auth
{
    public class AuthorizationTokens
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
