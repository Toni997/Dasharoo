using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string ImagePath { get; set; }
        public string SourcePath { get; set; }
        public bool IsRemix { get; set; }
        public bool IsOfficialRemix { get; set; }

        [ForeignKey(nameof(Visibility))]
        public int? VisibilityId { get; set; }
        public virtual Visibility RecordVisibility { get; set; }

        [ForeignKey(nameof(Record))]
        public int? OriginalRecordId { get; set; }
        public virtual Record OriginalRecord { get; set; }

        [ForeignKey(nameof(Playlist))]
        public int? OriginalPlaylistId { get; set; }
        public Playlist OriginalPlaylist { get; set; }

        public ICollection<RecordAuthor> RecordAuthors { get; set; }
        public ICollection<RecordSupporter> RecordSupporters { get; set; }
        public ICollection<RecordGenre> RecordGenres { get; set; }
        public virtual ICollection<RecordPlaylist> RecordPlaylists { get; set; }
    }
}
