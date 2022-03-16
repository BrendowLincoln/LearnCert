namespace LearnCert.Domain.Infrastructure;

public interface IBaseState
{
    Guid Id { get; set; }
}

public abstract class BaseState : IBaseState
{
    public virtual Guid Id { get; set; }
}