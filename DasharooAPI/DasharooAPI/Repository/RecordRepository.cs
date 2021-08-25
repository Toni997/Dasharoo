using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Data;
using DasharooAPI.IRepository;

namespace DasharooAPI.Repository
{
    public class RecordRepository : Repository<Record>, IRecordRepository
    {
        public RecordRepository(DasharooDbContext context) : base(context)
        {
        }

        public Task<Record> GetByIdWithAuthorsGenresSupporters(int id)
        {
            return Get(x => x.Id == id, new List<string>{
                "RecordAuthors", "RecordAuthors.Author",
                "RecordSupporters", "RecordSupporters.Supporter",
                "RecordGenres", "RecordGenres.Genre"
            });
        }

        public Task<IList<Record>> GetAllWithAuthorsGenresSupporters()
        {
            return GetAll(includes: new List<string>
            {
                "RecordAuthors", "RecordAuthors.Author",
                "RecordSupporters", "RecordSupporters.Supporter",
                "RecordGenres", "RecordGenres.Genre"
            });
        }
    }
}
