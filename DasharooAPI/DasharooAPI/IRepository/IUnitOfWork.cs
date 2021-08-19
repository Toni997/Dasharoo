using System;
using System.Collections.Generic;
using System.Linq;
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
        Task Save();
    }
}
