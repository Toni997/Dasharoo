namespace DasharooAPI.Models
{
    public class RecordGenreDto
    {
        public int RecordId { get; set; }
        public RecordDto Record { get; set; }

        public int GenreId { get; set; }
        public GenreOnRecordDto Genre { get; set; }
    }
}
