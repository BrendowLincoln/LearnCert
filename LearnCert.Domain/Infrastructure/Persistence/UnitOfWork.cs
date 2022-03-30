using NHibernate;
using ISession = NHibernate.ISession;

namespace LearnCert.Domain.Infrastructure.Persistence;

public interface IUnitOfWork
{
    TEntity GetById<TEntity>(Guid id) where TEntity : class;
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

    public TEntity GetById<TEntity>(Guid id) where TEntity : class
    {
        return _session.Get<TEntity>(id);
    }

    public void Save<TEntity>(TEntity entity) where TEntity : class
    {
        _session.Save(entity);
        _session.Flush();
    }
    
    public void Delete<TEntity>(TEntity entity) where TEntity : class
    {
        _session.Delete(entity);
        _session.Flush();
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

}
