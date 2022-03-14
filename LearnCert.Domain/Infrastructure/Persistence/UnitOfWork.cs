using NHibernate;
using ISession = NHibernate.ISession;

namespace LearnCert.Domain.Infrastructure.Persistence
{
    public interface IUnitOfWork
    {
        void Save<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        IQueryable<T> Query<T>();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        private ITransaction _transaction;
    
        public UnitOfWork(ISession session)
        {
            _session = session;
        }
    
        public void Save<TEntity>(TEntity entity) where TEntity : class
        {
            BeginTransaction();
            _session.Save(entity);
            CloseTransaction();
        }
    
        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            BeginTransaction();
            _session.Delete(entity);
            CloseTransaction();
        }

        public IQueryable<T> Query<T>()
        {
            return _session.Query<T>();
        }
        
        private void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }
    
        private async Task Commit()
        {
            await _transaction.CommitAsync();
        }
        
        private void CloseTransaction()
        {
            if(_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

    }

}