using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DasharooAPI.Data;
using DasharooAPI.IRepository;
using DasharooAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace DasharooAPI.Repository
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(DasharooDbContext context) : base(context)
        {
        }

        private static IIncludableQueryable<Genre, object> Includes(IQueryable<Genre> x)
        {
            return x.Include(x => x.RecordGenres)
                        .ThenInclude(x => x.Record);
        }

        public async Task<Genre> GetByIdWithRecords(int id)
        {
            return await Get(x => x.Id == id, Includes);
        }
    }
}
