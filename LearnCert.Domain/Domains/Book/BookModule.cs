using LearnCert.Domain.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace LearnCert.Domain.Domains.Book;

public class BookModule : IDependencyInjection
{
    public void Compose(IServiceCollection services)
    {
        services.AddScoped<IBookReadRepository, BookReadRepository>();
        services.AddScoped<IBookWriteRepository, BookWriteRepository>();
        services.AddScoped<IBookValidator, BookValidator>();
        
        services.AddScoped<BookCommandHandler>();
    }
}