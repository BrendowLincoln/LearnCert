using NHibernate;
using ISession = NHibernate.ISession;

namespace LearnCert.Api.Infrastructure.Persistence
{

    public class DynamoUnitOfWork : IUnitOfWork
    {
    
        public DynamoUnitOfWork(ISession session)
        {
        }
    
        public void Save<TEntity>(TEntity entity) where TEntity : class
        {
        }
    
        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
        }

        public IQueryable<T> Query<T>()
        {
            return null;
        }
    }

}