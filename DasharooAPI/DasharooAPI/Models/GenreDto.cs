using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DasharooAPI.Models
{
    public class CreateGenreDto
    {
        [Required] [MaxLength(30)] public string Name { get; set; }

        public int? ParentGenreId { get; set; }
    }

    public class GenreOnRecordDto : CreateGenreDto
    {
        public int Id { get; set; }
    }

    public class GenreDto : GenreOnRecordDto
    {
        public virtual ICollection<RecordGenreDto> RecordGenres { get; set; }
    }

    public class UpdateGenreDto : CreateGenreDto
    {
    }
}
