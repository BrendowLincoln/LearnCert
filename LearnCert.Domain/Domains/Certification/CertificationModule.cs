﻿using LearnCert.Domain.Domains.Certification.Write.CommandHandlers;
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
    }
}