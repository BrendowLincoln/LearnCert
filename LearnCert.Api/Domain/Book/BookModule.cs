namespace LearnCert.Api.Domain.Book;

public class BookModule : IDependencyInjection
{
    public void Compose(IServiceCollection services)
    {
        services.AddScoped<IBookReadRepository, BookReadRepository>();
    }
}