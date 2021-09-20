using System;
using System.Threading.Tasks;
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
        private IGenericRepository<RefreshToken> _refreshTokens;
        private IGenericRepository<RecordGenre> _recordGenres;
        private IGenericRepository<RecordPlaylist> _recordPlaylists;
        private IGenericRepository<RecordAuthor> _recordAuthors;
        private IGenericRepository<RecordSupporter> _recordSupporters;
        private IGenericRepository<AuthorFollower> _authorFollowers;

        public UnitOfWork(DasharooDbContext context)
        {
            _context = context;
        }

        public IRecordRepository Records => _records ??= new RecordRepository(_context);
        public IPlaylistRepository Playlists => _playlists ??= new PlaylistRepository(_context);
        public IGenreRepository Genres => _genres ??= new GenreRepository(_context);
        public IGenericRepository<RefreshToken> RefreshTokens => _refreshTokens ??= new GenericRepository<RefreshToken>(_context);
        public IGenericRepository<RecordGenre> RecordGenres => _recordGenres ??= new GenericRepository<RecordGenre>(_context);
        public IGenericRepository<RecordPlaylist> RecordPlaylists => _recordPlaylists ??= new GenericRepository<RecordPlaylist>(_context);
        public IGenericRepository<RecordAuthor> RecordAuthors => _recordAuthors ??= new GenericRepository<RecordAuthor>(_context);
        public IGenericRepository<RecordSupporter> RecordSupporters => _recordSupporters ??= new GenericRepository<RecordSupporter>(_context);
        public IGenericRepository<AuthorFollower> AuthorFollowers => _authorFollowers ??= new GenericRepository<AuthorFollower>(_context);

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
