namespace LearnCert.Domain.Infrastructure.Persistence;

public abstract class BaseAggregate<TState> : IAggregate<TState> where TState : IBaseState
{
    protected TState State;

    public virtual Guid Id => State.Id;
    
    public TState GetState()
    {
        return State;
    }
}