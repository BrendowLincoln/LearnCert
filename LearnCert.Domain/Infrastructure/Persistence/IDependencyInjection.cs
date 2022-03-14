using Microsoft.Extensions.DependencyInjection;

namespace LearnCert.Domain.Infrastructure.Persistence;
public interface IDependencyInjection
{
    public void Compose(IServiceCollection services);
} 