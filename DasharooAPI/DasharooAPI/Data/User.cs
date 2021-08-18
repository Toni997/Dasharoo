using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DasharooAPI.Data
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Verified { get; set; }

        public ICollection<Playlist> Playlists { get; set; }

        [InverseProperty("Authors")]
        public ICollection<Record> Records { get; set; }

        [InverseProperty("Supporters")]
        public virtual ICollection<Record> SupportedRecords { get; set; }

        public virtual ICollection<User> Followers { get; set; }
        public virtual ICollection<User> Followings { get; set; }

    }
}
