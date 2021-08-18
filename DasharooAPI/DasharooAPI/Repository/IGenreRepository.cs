using DasharooAPI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using DasharooAPI.IRepository;
using DasharooAPI.Models;

namespace DasharooAPI.Repository
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        Task<Genre> GetById(int genreId);
        Task<Genre> GetByIdWithRecords(int genreId);
    }
}