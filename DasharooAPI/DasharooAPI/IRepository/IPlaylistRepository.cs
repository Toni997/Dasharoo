using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Data;

namespace DasharooAPI.IRepository
{
    public interface IPlaylistRepository : IGenericRepository<Playlist>
    {
        Task<Playlist> GetByIdWithRecords(int id);
        Task<IList<Playlist>> GetAllWithRecords();
    }
}
