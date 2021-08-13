using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DasharooAPI.Data
{
    public class DasharooDbContext : DbContext
    {
        public DasharooDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
