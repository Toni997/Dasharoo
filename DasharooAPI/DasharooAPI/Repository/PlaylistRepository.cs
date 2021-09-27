using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Data;
using DasharooAPI.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DasharooAPI.Repository
{
    public class PlaylistRepository : GenericRepository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(DasharooDbContext context) : base(context)
        {
        }

        private static IIncludableQueryable<Playlist, object> Includes(IQueryable<Playlist> x)
        {
            return x.Include(x => x.Records)
                        .ThenInclude(x => x.CreatedBy)
                    .Include(x => x.Records)
                        .ThenInclude(x => x.RecordAuthors)
                    .Include(x => x.Records)
                        .ThenInclude(x => x.RecordAuthors)
                        .ThenInclude(x => x.Author)
                    .Include(x => x.RecordPlaylists)
                        .ThenInclude(x => x.Record)
                        .ThenInclude(x => x.CreatedBy)
                    .Include(x => x.RecordPlaylists)
                        .ThenInclude(x => x.Record)
                        .ThenInclude(x => x.RecordAuthors)
                    .Include(x => x.RecordPlaylists)
                        .ThenInclude(x => x.Record)
                        .ThenInclude(x => x.RecordAuthors)
                        .ThenInclude(x => x.Author)

                        .Include(x => x.Author);
        }

        public Task<Playlist> GetByIdWithRecordsAndAuthor(int id)
        {
            return Get(x => x.Id == id, Includes);
        }

        public Task<IList<Playlist>> GetAllWithRecordsAndAuthor()
        {
            return GetAll(includes: Includes);
        }

        public Task<IList<Playlist>> GetAllByUserForSidebar(string userId)
        {
            return GetAll(x => x.AuthorId == userId);
        }
    }
}
