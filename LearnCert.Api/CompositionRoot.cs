namespace LearnCert.Api;
using LearnCert.Api.Infrastructure.Persistence;
using LearnCert.Api;


public class CompositionRoot : IDependencyInjection
{
    public void Compose(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}