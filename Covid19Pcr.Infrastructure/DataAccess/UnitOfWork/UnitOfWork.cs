using Covid19Pcr.Application.Interfaces;
using Covid19Pcr.Infrastructure.DataAccess.Repository;
using Covid19Pcr.Infrastructure.Extensions;
using MediatR;
using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace Covid19Pcr.Infrastructure.DataAccess.UnitOfWork
{
    public class UnitofWork : IUnitofWork
    {

        private readonly Covid19PcrContext _context;
        private readonly IMediator _mediator;
        private Hashtable _repositories;
        public UnitofWork(Covid19PcrContext context, IMediator mediator)
        {
            _context = context;
            this._mediator = mediator;
        }
        public async Task<bool> Complete(CancellationToken cancellationToken = default)
        {
            var result = await _context.SaveChangesAsync() > 0;
            await this._mediator.DispatchDomainEventsAsync(this._context);
            return result;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Hashtable();
            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (IRepository<TEntity>)_repositories[type];
        }
    }
}
