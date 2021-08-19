using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Data;
using DasharooAPI.IRepository;

namespace DasharooAPI.Repository
{
    public class RecordRepository : Repository<Record>, IRecordRepository
    {
        public RecordRepository(DasharooDbContext context) : base(context)
        {
        }
    }
}
