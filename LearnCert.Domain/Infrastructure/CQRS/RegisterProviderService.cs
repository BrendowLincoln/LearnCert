using System.Collections.Concurrent;
using LearnCert.Domain.Infrastructure.CQRS;
using Microsoft.Extensions.DependencyInjection;
using NHibernate.Util;

namespace LearnCert.Domain.Infrastructure.Persistence;

public interface IRegisterProviderService
{
    TAggregate GetAggregate<TState, TAggregate> (TState typeState) where TState : IBaseState where TAggregate : IAggregate<TState>;
    ICommandHandler<TCommand> GetCommandHandler<TCommand>(TCommand command) where TCommand : ICommand;
}
public class RegisterProviderService : IRegisterProviderService
{
    private readonly ConcurrentDictionary<Type, Type> _commandHandlerMap = new();
    private readonly ConcurrentDictionary<Type, Type> _aggregateMap = new();
    private readonly IServiceProvider _serviceProvider;

    public RegisterProviderService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        RegisterCommandHandlers();
        RegisterAggregates();
    }

    public TAggregate GetAggregate<TState, TAggregate>(TState typeState) where TState : IBaseState where TAggregate : IAggregate<TState>
    {
        var type = _aggregateMap.FirstOrDefault(x => x.Value == typeState.GetType());
        
        var aggregate = Activator.CreateInstance(type.Key, typeState)!;
        return (TAggregate) aggregate;
    }

    public ICommandHandler<TCommand> GetCommandHandler<TCommand>(TCommand command) where TCommand : ICommand
    {
        var map = _commandHandlerMap.FirstOrDefault(x => x.Key.Name == command.GetType().Name);
        var commandHandler = (ICommandHandler<TCommand>) _serviceProvider.CreateScope().ServiceProvider.GetRequiredService(map.Value);
        return commandHandler;
    }

    private void RegisterCommandHandlers()
    {
        var commandHandlers = typeof(RegisterProviderService).Assembly.GetTypes()
            .Where(t => !t.IsInterface 
                        && t.GetInterfaces()
                            .Any(c => c.IsGenericType && c.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
            .ToList();

        foreach (var commandHandler in commandHandlers)
        {
            var commands = commandHandlers.Select(x => x.GetInterfaces().Where(c => c.IsGenericType && c.GetGenericTypeDefinition() == typeof(ICommandHandler<>))).FirstOrDefault().ToList();

            commands.ForEach(x =>
            {
                var cmd = x.GenericTypeArguments.FirstOrDefault();
                if (cmd != null)
                {
                    _commandHandlerMap.TryAdd(cmd, commandHandler);
                }
            });
        }
    }

    private void RegisterAggregates()
    {
        typeof(BaseAggregate<IBaseState>).Assembly
            .GetTypes()
            .Where(x => !x.IsInterface && x.BaseType.Name.Contains(nameof(BaseAggregate<IBaseState>)))
            .ForEach(x =>
            {
                var stateType = x.BaseType.GetGenericArguments().First();
                if (stateType != null)
                {
                    _aggregateMap.TryAdd(x, stateType);
                }
            });
    }
}