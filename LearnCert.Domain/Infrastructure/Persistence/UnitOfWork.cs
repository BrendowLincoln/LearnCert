using NHibernate;
using ISession = NHibernate.ISession;

namespace LearnCert.Domain.Infrastructure.Persistence
{
    public interface IUnitOfWork
    {
        void Save<TEntity>(TEntity entity) where TEntity : class;
        void Delete<TEntity>(TEntity entity) where TEntity : class;
        TEntity Merge<TEntity>(TEntity entity) where TEntity : class;
        IQueryable<T> Query<T>();
        IQuery GetNamedQuery(string namedQuery);
        IQuery ExecuteQuery(string queryString);
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
        
        public TEntity Merge<TEntity>(TEntity entity) where TEntity : class
        {
            var result = _session.Merge(entity);
            _session.Flush();
            return result;
        }

        public IQueryable<T> Query<T>()
        {
            return _session.Query<T>();
        }
        
        public IQuery GetNamedQuery(string namedQuery)
        {
            return _session.GetNamedQuery(namedQuery);
        }

        public IQuery ExecuteQuery(string queryString)
        {
            return _session.CreateSQLQuery(queryString);
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