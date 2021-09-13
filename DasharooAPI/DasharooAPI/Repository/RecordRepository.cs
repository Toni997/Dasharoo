using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Data;
using DasharooAPI.IRepository;
using DasharooAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DasharooAPI.Repository
{
    public class RecordRepository : GenericRepository<Record>, IRecordRepository
    {
        public RecordRepository(DasharooDbContext context) : base(context)
        {
        }

        private static IIncludableQueryable<Record, object> Includes(IQueryable<Record> x)
        {
            return x.Include(x => x.RecordAuthors)
                        .ThenInclude(x => x.Author)
                    .Include(x => x.RecordSupporters)
                        .ThenInclude(x => x.Supporter)
                    .Include(x => x.RecordGenres)
                        .ThenInclude(x => x.Genre)
                    .Include(x => x.CreatedBy);
        }

        public Task<Record> GetByIdWithAuthorsGenresSupporters(int id)
        {
            return Get(x => x.Id == id, Includes);
        }

        public Task<IList<Record>> GetAllWithAuthorsGenresSupporters()
        {
            return GetAll(includes: Includes);
        }
    }
}
