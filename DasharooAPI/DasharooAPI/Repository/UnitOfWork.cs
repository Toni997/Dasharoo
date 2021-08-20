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
        private IRecordRepository _records;
        private IPlaylistRepository _playlists;
        private IGenreRepository _genres;
        private IGenericRepository<RecordGenre> _recordGenre;

        public UnitOfWork(DasharooDbContext context)
        {
            _context = context;
        }

        public IRecordRepository Records => _records ??= new RecordRepository(_context);
        public IPlaylistRepository Playlists => _playlists ??= new PlaylistRepository(_context);
        public IGenreRepository Genres => _genres ??= new GenreRepository(_context);
        public IGenericRepository<RecordGenre> RecordGenre => _recordGenre ??= new Repository<RecordGenre>(_context);

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
