namespace LearnCert.Domain.Infrastructure.Persistence;

public interface IAggregate<TState>
{
    Guid Id { get; }
    TState GetState();
}