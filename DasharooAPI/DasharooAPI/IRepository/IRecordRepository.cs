using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Data;

namespace DasharooAPI.IRepository
{
    public interface IRecordRepository : IGenericRepository<Record>
    {
        Task<Record> GetByIdWithAuthorsGenresSupporters(int id);
        Task<IList<Record>> GetAllWithAuthorsGenresSupporters();
    }
}
