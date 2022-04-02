namespace LearnCert.Domain.Infrastructure.CQRS;

public interface ICommandHandler<TCommand> where TCommand: ICommand
{
    void Handle(TCommand cmd);
}