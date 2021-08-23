using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace DasharooAPI.Data
{
    public class AuthorFollower
    {
        public string AuthorId { get; set; }
        public User Author { get; set; }

        public string FollowerId { get; set; }
        public User Follower { get; set; }
    }
}
