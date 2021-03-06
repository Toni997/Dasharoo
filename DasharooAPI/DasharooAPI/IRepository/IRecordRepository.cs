using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace DasharooAPI.IRepository
{
    public interface IRecordRepository : IGenericRepository<Record>
    {
        Task<Record> GetByIdWithAuthorsGenresSupporters(int id);
        Task<IList<Record>> GetAllWithAuthorsGenresSupporters();
        Task<IList<Record>> GetByKeywordWithAuthorsGenresSupporters(string keyword);
    }
}
