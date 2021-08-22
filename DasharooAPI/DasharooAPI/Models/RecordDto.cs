using System;
using System.Collections.Generic;

namespace DasharooAPI.Models
{
    public class BaseRecordDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string SourcePath { get; set; }
        public bool IsRemix { get; set; }
        public int? VisibilityId { get; set; }
        public int? OriginalRecordId { get; set; }
    }

    public class CreateRecordDto : BaseRecordDto
    {
        // delete, calculate this on a file
        public string SourcePath { get; set; }

        public ICollection<string> AuthorsIds { get; set; }
        public ICollection<int> GenresIds { get; set; }
    }

    public class RecordDto : BaseRecordDto
    {
        public int Id { get; set; }
        public bool IsOfficialRemix { get; set; }
        public ulong Plays { get; set; }
        public TimeSpan Duration { get; set; }

        public ICollection<UserDto> Authors { get; set; }
        public ICollection<RecordGenreDto> RecordGenres { get; set; }
        public virtual ICollection<UserDto> Supporters { get; set; }
        // public virtual ICollection<Playlist> Playlists { get; set; }
    }

    public class UpdateRecordDto : CreateRecordDto
    {
    }
}
