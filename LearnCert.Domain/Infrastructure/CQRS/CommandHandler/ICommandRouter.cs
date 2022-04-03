namespace LearnCert.Domain.Infrastructure.CQRS;

public interface ICommandRouter
{
    void Send<TCommand>(TCommand command) where TCommand : ICommand;
}