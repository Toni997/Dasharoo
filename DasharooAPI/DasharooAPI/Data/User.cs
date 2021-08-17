using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DasharooAPI.Data
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Playlist> Playlists { get; set; }
        public virtual ICollection<Record> Records { get; set; }
        public virtual ICollection<User> Followers { get; set; }
        public virtual ICollection<User> Following { get; set; }

    }
}
