using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public List<string> IncludeAuthorsGenresSupporters { get; } = new()
        {
            "RecordAuthors",
            "RecordAuthors.Author",
            "RecordSupporters",
            "RecordSupporters.Supporter",
            "RecordGenres",
            "RecordGenres.Genre"
        };

        public Task<Record> GetByIdWithAuthorsGenresSupporters(int id)
        {
            return Get(x => x.Id == id, IncludeAuthorsGenresSupporters);
        }

        public Task<IList<Record>> GetAllWithAuthorsGenresSupporters()
        {
            return GetAll(includes: IncludeAuthorsGenresSupporters);
        }
    }
}
