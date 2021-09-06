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
        public string ArtistName { get; set; }
        public bool Verified { get; set; }
        public string ImagePath { get; set; }
        public string BackgroundPath { get; set; }

        public ICollection<Record> Records { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
        public ICollection<RecordSupporter> RecordSupporters { get; set; }
        public ICollection<RecordAuthor> RecordAuthors { get; set; }
        public virtual ICollection<AuthorFollower> Followers { get; set; }
        public virtual ICollection<AuthorFollower> Followings { get; set; }
    }
}
