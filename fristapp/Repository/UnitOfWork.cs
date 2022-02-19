using fristapp.data;
using fristapp.IRepository;
using System;

namespace fristapp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _context;
        private IGenericIRepository<country> _countries;
        private IGenericIRepository<hotel> _hotels;

        public UnitOfWork(DataBaseContext context,
            IGenericIRepository<country> countries,
            IGenericIRepository<hotel> hotels)
        {
            _context = context;
            _countries = countries;
            _hotels = hotels;
        }
        public IGenericIRepository<country> Countries => _countries ??= new GenericRepository<country>(_context);

        public IGenericIRepository<hotel> Hotels => _hotels ??= new GenericRepository<hotel>(_context);



        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
