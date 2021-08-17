using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DasharooAPI.Data
{
    public class Record
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public ulong Plays { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string SourcePath { get; set; }
        public bool IsRemix { get; set; }
        public bool IsOfficialRemix { get; set; }

        [ForeignKey(nameof(Visibility))]
        public int VisibilityId { get; set; }
        public virtual Visibility RecordVisibility { get; set; }

        [ForeignKey(nameof(Record))]
        public int? OriginalRecordId { get; set; }
        public virtual Record OriginalRecord { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }

    }
}