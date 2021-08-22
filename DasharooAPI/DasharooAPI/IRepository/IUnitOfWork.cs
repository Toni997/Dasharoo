using System;
using System.Threading.Tasks;
using DasharooAPI.Data;
using DasharooAPI.Repository;

namespace DasharooAPI.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IRecordRepository Records { get; }
        IGenreRepository Genres { get; }
        IPlaylistRepository Playlists { get; }
        IGenericRepository<RecordGenre> RecordGenres { get; }
        Task Save();
    }
}
