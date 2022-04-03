namespace LearnCert.Domain.Infrastructure.Persistence.QueryHandlers;

public interface IBaseQueryHandler<TBaseModel> where TBaseModel : BaseModel
{
    TBaseModel GetById(Guid id);
    IQueryable<TBaseModel> Query();
}

public class BaseQueryHandler<TBaseModel> : IBaseQueryHandler<TBaseModel> where TBaseModel : BaseModel
{
    private readonly IUnitOfWork _unitOfWork;

    protected BaseQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public TBaseModel GetById(Guid id)
    {
        return _unitOfWork.GetById<TBaseModel>(id);
    }

    public IQueryable<TBaseModel> Query()
    {
        return _unitOfWork.Query<TBaseModel>();
    }
}