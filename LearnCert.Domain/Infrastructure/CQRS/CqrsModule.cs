using Microsoft.Extensions.DependencyInjection;

namespace LearnCert.Domain.Infrastructure.Persistence;

public class CqrsModule : IDependencyInjection
{
    public void Compose(IServiceCollection services)
    {
        services.AddSingleton<IRegisterProviderService, RegisterProviderService>();
    }
}