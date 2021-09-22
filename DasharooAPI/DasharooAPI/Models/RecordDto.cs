using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DasharooAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.Language;

namespace DasharooAPI.Models
{
    public class BaseRecordDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsRemix { get; set; }
        public int? VisibilityId { get; set; }
        public int? OriginalRecordId { get; set; }
        public int? OriginalPlaylistId { get; set; }
    }

    public class CreateRecordDto : BaseRecordDto
    {
        [Required]
        public IFormFile Source { get; set; }
        public IFormFile Image { get; set; }
        [Required]
        public ICollection<string> AuthorsIds { get; set; }
        [Required]
        public ICollection<int> GenresIds { get; set; }
    }

    public class RecordDto : BaseRecordDto
    {
        public int Id { get; set; }
        public string SourcePath { get; set; }
        public string ImagePath { get; set; }
        public bool IsOfficialRemix { get; set; }
        public ulong Plays { get; set; }
        public TimeSpan Duration { get; set; }
        public GetUserDto CreatedBy { get; set; }

        public ICollection<RecordAuthorDto> RecordAuthors { get; set; }
        public ICollection<RecordGenreDto> RecordGenres { get; set; }
        public virtual ICollection<RecordSupporterDto> RecordSupporters { get; set; }
        // public virtual ICollection<Playlist> Playlists { get; set; }
    }

    public class UpdateRecordDto : CreateRecordDto
    {
        public new IFormFile Source { get; set; }
    }

    public class RecordForQueueDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SourcePath { get; set; }
        public GetUserDto CreatedBy { get; set; }
        public ICollection<RecordAuthorDto> RecordAuthors { get; set; }
        public ICollection<RecordGenreDto> RecordGenres { get; set; }
    }
}
