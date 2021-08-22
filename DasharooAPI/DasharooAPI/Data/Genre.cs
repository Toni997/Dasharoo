using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DasharooAPI.Data
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(Genre))]
        public int? ParentGenreId { get; set; }
        public Genre ParentGenre { get; set; }

        public virtual ICollection<RecordGenre> RecordGenres { get; set; }
    }
}
