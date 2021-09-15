using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DasharooAPI.Models.Auth.Facebook
{
    public class FacebookUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
    }
}
