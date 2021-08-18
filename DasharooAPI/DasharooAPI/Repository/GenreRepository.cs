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
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {

        public GenreRepository(DasharooDbContext context) : base(context)
        {
        }

        public async Task<Genre> GetById(int genreId)
        {
            return await Get(x => x.Id == genreId);
        }

        public async Task<Genre> GetByIdWithRecords(int genreId)
        {
            return await Get(expression: x => x.Id == genreId,
                                                include: x =>
                                                    x.Include(q => q.Records));
        }

        public async Task<Genre> CreateGenre(Genre genre)
        {

            await Insert(genre);

            return genre;
        }
    }
}
