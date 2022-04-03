namespace LearnCert.Domain.Infrastructure.Persistence;

public interface IBaseWriteRepository<in TState, out TAggregate> where TState : IBaseState where TAggregate : IAggregate<TState>
{
    TAggregate GetById(Guid aggregateId);
    void Save<TAggregate>(TAggregate aggregate) where TAggregate : class;
    void Delete<TAggregate>(TAggregate entity) where TAggregate : class;
}

public abstract class BaseWriteRepository<TState, TAggregate> : IBaseWriteRepository<TState, TAggregate> 
    where TAggregate : IAggregate<TState> 
    where TState : class, IBaseState
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IRegisterProviderService _registerProviderService;

    protected BaseWriteRepository(IUnitOfWork unitOfWork, IRegisterProviderService registerProviderService)
    {
        _unitOfWork = unitOfWork;
        _registerProviderService = registerProviderService;
    }

    public TAggregate GetById(Guid aggregateId)
    {
        var state = _unitOfWork.GetById<TState>(aggregateId);
        if (state == null) 
            return (TAggregate) (IAggregate<IBaseState>) null;
        
        var aggregate = _registerProviderService.GetAggregate<TState, TAggregate>(state);
        return aggregate;
    }

    public void Save<TAggregate>(TAggregate aggregate) where TAggregate : class
    {
        var state = ((IAggregate<TState>) aggregate).GetState();
        _unitOfWork.Save(state);
    }

    public void Delete<TAggregate>(TAggregate aggregate) where TAggregate : class
    {
        var state = ((IAggregate<TState>) aggregate).GetState();
        _unitOfWork.Delete(state);
    }

}