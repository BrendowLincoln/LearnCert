using Microsoft.Extensions.DependencyInjection;

namespace LearnCert.Domain;

public class BookModule : IDependencyInjection
{
    public void Compose(IServiceCollection services)
    {
        services.AddScoped<IBookReadRepository, BookReadRepository>();
    }
}