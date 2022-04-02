using System.Collections.Concurrent;
using LearnCert.Domain.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using NHibernate.Util;

namespace LearnCert.Domain.Infrastructure.CQRS;

public class CommandRouter : ICommandRouter
{
    
    private readonly ConcurrentDictionary<Type, Type> _commandHandlerMap = new ConcurrentDictionary<Type, Type>();
    private readonly IServiceProvider _serviceProvider;
    
    public CommandRouter(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        
        var commandHandlers = typeof(CommandRouter).Assembly.GetTypes()
            .Where(t => !t.IsInterface 
                        && t.GetInterfaces()
                            .Any(c => c.IsGenericType && c.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
            .ToList();

        foreach (var commandHandler in commandHandlers)
        {
            var commands = commandHandlers.Select(x => x.GetInterfaces().Where(c => c.IsGenericType && c.GetGenericTypeDefinition() == typeof(ICommandHandler<>)));

            commands.ForEach(x =>
            {
                var cmd = x.FirstOrDefault().GenericTypeArguments.FirstOrDefault();
                _commandHandlerMap.TryAdd(commandHandler, cmd);
            });
        }

    }
    
    public void Send<TCommand>(TCommand command) where TCommand : ICommand
    {
        using var scope = _serviceProvider.CreateScope();
        var map = _commandHandlerMap.FirstOrDefault(x => x.Value.Name == command.GetType().Name);
        var commandHandler = (ICommandHandler<TCommand>) scope.ServiceProvider.GetRequiredService(map.Key);
        commandHandler.Handle(command);
    }
}