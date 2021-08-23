using System;
using System.Collections.Generic;
using DasharooAPI.Data;
using Microsoft.AspNetCore.Http;

namespace DasharooAPI.Models
{
    public class BaseRecordDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string SourcePath { get; set; }
        public string ImagePath { get; set; }
        public bool IsRemix { get; set; }
        public int? VisibilityId { get; set; }
        public int? OriginalRecordId { get; set; }
        public int? OriginalPlaylistId { get; set; }
    }

    public class CreateRecordDto : BaseRecordDto
    {
        public IFormFile Source { get; set; }
        public ICollection<string> AuthorsIds { get; set; }
        public ICollection<int> GenresIds { get; set; }
    }

    public class RecordDto : BaseRecordDto
    {
        public int Id { get; set; }
        public bool IsOfficialRemix { get; set; }
        public ulong Plays { get; set; }
        public TimeSpan Duration { get; set; }

        public ICollection<RecordAuthor> RecordAuthors { get; set; }
        public ICollection<RecordGenreDto> RecordGenres { get; set; }
        public virtual ICollection<RecordSupporter> RecordSupporters { get; set; }
        // public virtual ICollection<Playlist> Playlists { get; set; }
    }

    public class UpdateRecordDto : CreateRecordDto
    {
    }
}
