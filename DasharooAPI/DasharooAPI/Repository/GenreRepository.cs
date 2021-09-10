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

namespace DasharooAPI.Repository
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(DasharooDbContext context) : base(context)
        {
        }

        public async Task<Genre> GetByIdWithRecords(int id)
        {
            return await Get(x => x.Id == id, new List<string> { "Records" });
        }
    }
}
