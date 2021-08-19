using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Data;

namespace DasharooAPI.Models
{
    public class CreatePlaylistDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int? VisibilityId { get; set; }
        public string AuthorId { get; set; }
    }

    public class PlaylistDto : CreatePlaylistDto
    {
        public int Id { get; set; }
        public ICollection<RecordDto> Records { get; set; }
    }

    public class UpdatePlaylistDto : CreatePlaylistDto
    {
    }
}
