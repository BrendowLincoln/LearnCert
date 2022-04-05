using LearnCert.Domain.Domains.Certification.Write.Aggregates;
using LearnCert.Domain.Domains.Certification.Write.Commands;
using LearnCert.Domain.Domains.Certification.Write.Repositories;
using LearnCert.Domain.Infrastructure.CQRS;

namespace LearnCert.Domain.Domains.Certification.Write.CommandHandlers;

public class CertificationCommandHandler : ICommandHandler<CreateCertificationCommand>
{

    private readonly ICertificationWriteRepository _certificationWriteRepository;

    public CertificationCommandHandler(ICertificationWriteRepository certificationWriteRepository)
    {
        _certificationWriteRepository = certificationWriteRepository;
    }

    public void Handle(CreateCertificationCommand cmd)
    {
        var aggregate = new CertificationAggregate(cmd);
        // validate
        _certificationWriteRepository.Save(aggregate);
    }
}