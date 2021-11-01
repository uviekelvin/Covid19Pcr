using System;
using System.Threading;
using System.Threading.Tasks;

namespace Covid19Pcr.Application.Interfaces
{
    public interface IUnitofWork : IDisposable
    {
        Task<bool> Complete(CancellationToken cancellationToken = default);
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;

    }
}
