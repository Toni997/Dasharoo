using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Data;
using DasharooAPI.IRepository;

namespace DasharooAPI.Repository
{
    public class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(DasharooDbContext context) : base(context)
        {
        }

        public List<string> Includes { get; } = new()
        {
            "Records",
            "Records.CreatedBy",
            "Records.RecordAuthors",
            "Records.RecordAuthors.Author",
            "Author"
        };

        public Task<Playlist> GetByIdWithRecordsAndAuthor(int id)
        {
            return Get(x => x.Id == id, includes: Includes);

        }
        public Task<IList<Playlist>> GetAllWithRecords()
        {
            return GetAll(includes: Includes);
        }
    }
}
