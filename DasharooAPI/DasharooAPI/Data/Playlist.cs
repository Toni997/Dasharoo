using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace DasharooAPI.Data
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImagePath { get; set; }
        public string BackgroundPath { get; set; }

        [ForeignKey(nameof(Visibility))]
        public int? VisibilityId { get; set; }
        public Visibility PlaylistVisibility { get; set; }

        [ForeignKey(nameof(User))]
        public string AuthorId { get; set; }
        public User Author { get; set; }

        public virtual ICollection<RecordPlaylist> RecordPlaylists { get; set; }
        public ICollection<Record> Records { get; set; }
    }
}