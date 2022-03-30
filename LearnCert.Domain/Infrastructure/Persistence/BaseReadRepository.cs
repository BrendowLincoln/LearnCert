using FluentNHibernate.Conventions;

namespace LearnCert.Domain.Infrastructure.Persistence;

public interface IBaseReadRepository<TEntity>
{
    TEntity GetById<TEntity>(Guid id) where TEntity : class;
}

public class BaseReadRepository<TEntity> : IBaseReadRepository<TEntity>
{

    private readonly IUnitOfWork _unitOfWork;

    protected BaseReadRepository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public TEntity GetById<TEntity>(Guid id) where TEntity : class
    {
        return _unitOfWork.GetById<TEntity>(id);
    }

}