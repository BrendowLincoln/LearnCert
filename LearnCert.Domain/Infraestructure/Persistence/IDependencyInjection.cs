using Microsoft.Extensions.DependencyInjection;

namespace LearnCert.Domain;
public interface IDependencyInjection
{
    public void Compose(IServiceCollection services);
} 