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
        IGenreRepository Genres { get; }
        // IGenericRepository<Record> Records { get; }
        // IGenericRepository<Playlist> Playlists { get; }
        Task Save();
    }
}
