using LearnCert.Domain.Domains.Book;
using LearnCert.Domain.Domains.Book.Read.QueryHandlers;
using LearnCert.Domain.Domains.Certification.Write.CommandHandlers;
using LearnCert.Domain.Domains.Certification.Write.Repositories;
using LearnCert.Domain.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace LearnCert.Domain.Domains.Certification;

public class CertificationModule : IDependencyInjection
{
    public void Compose(IServiceCollection services)
    {
        services.AddScoped<ICertificationWriteRepository, CertificationWriteRepository>();
        
        services.AddScoped<CertificationCommandHandler>();
        services.AddScoped<ICertificationQueryHandler, CertificationQueryHandler>();
        services.AddScoped<ICertificationFlatQueryHandler, CertificationFlatQueryHandler>();
        services.AddScoped<ICertificationValidator, CertificationValidator>();

    }
}