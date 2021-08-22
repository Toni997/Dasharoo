namespace DasharooAPI.Data
{
    public class RecordGenre
    {
        public int RecordId { get; set; }
        public Record Record { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
