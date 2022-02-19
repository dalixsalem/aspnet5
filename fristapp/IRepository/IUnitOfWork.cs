using fristapp.data;
using System;

namespace fristapp.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericIRepository<country> Countries { get; }
        IGenericIRepository<hotel> Hotels { get; }

    }
}
