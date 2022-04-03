using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Infrastructure.CQRS;

public class CommandRouter : ICommandRouter
{
    
    private readonly IRegisterProviderService _registerProviderService;

    public CommandRouter(IRegisterProviderService registerProviderService)
    {
        _registerProviderService = registerProviderService;
    }
    
    public void Send<TCommand>(TCommand command) where TCommand : ICommand
    {
        var commandHandler = _registerProviderService.GetCommandHandler(command);
        commandHandler.Handle(command);
    }
}