using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DasharooAPI.Data;
using DasharooAPI.IRepository;

namespace DasharooAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DasharooDbContext _context;
        private readonly IMapper _mapper;
        private IGenreRepository _genres;
        // private IGenericRepository<Record> _records;
        // private IGenericRepository<Playlist> _playlists;

        public UnitOfWork(DasharooDbContext context)
        {
            _context = context;
        }
        public IGenreRepository Genres => _genres ??= new GenreRepository(_context);
        // public IGenericRepository<Record> Records => _records ??= new Repository<Record>(_context);
        // public IGenericRepository<Playlist> Playlists => _playlists ??= new Repository<Playlist>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
