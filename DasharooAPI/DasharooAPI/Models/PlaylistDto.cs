using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Data;
using Microsoft.AspNetCore.Http;

namespace DasharooAPI.Models
{
    public class BasePlaylistDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int? VisibilityId { get; set; }
    }

    public class CreatePlaylistDto : BasePlaylistDto
    {
        public IFormFile Image { get; set; }
        public IFormFile Background { get; set; }
    }

    public class PlaylistDto : BasePlaylistDto
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string ImagePath { get; set; }
        public string BackgroundPath { get; set; }
        public ulong Listens { get; set; }

        public ICollection<RecordDto> Records { get; set; }
        public UserOnRecordDto Author { get; set; }
    }

    public class UpdatePlaylistDto : CreatePlaylistDto
    {
    }
}
