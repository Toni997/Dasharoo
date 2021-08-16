using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DasharooAPI.Data;
using DasharooAPI.IRepository;

namespace DasharooAPI.Repository
{
    public class UnitOfWork
    {
        private readonly DasharooDbContext _context;
        // private IGenericRepository<Country> _countries;
        // private IGenericRepository<Hotel> _hotels;

        public UnitOfWork(DasharooDbContext context)
        {
            _context = context;
        }
        // public IGenericRepository<Country> Countries => _countries ??= new GenericRepository<Country>(_context);
        // public IGenericRepository<Hotel> Hotels => _hotels ??= new GenericRepository<Hotel>(_context);

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
