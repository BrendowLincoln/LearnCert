using LearnCert.Domain.Domains.Book;
using LearnCert.Domain.Domains.Certification.Write.Aggregates;
using LearnCert.Domain.Domains.Certification.Write.Commands;
using LearnCert.Domain.Domains.Certification.Write.Repositories;
using LearnCert.Domain.Infrastructure.CQRS;

namespace LearnCert.Domain.Domains.Certification.Write.CommandHandlers;

public class CertificationCommandHandler : 
    ICommandHandler<CreateCertificationCommand>,
    ICommandHandler<UpdateCertificationCommand>
{

    private readonly ICertificationWriteRepository _certificationWriteRepository;
    private readonly ICertificationValidator _certificationValidator;

    public CertificationCommandHandler(
        ICertificationWriteRepository certificationWriteRepository, 
        ICertificationValidator certificationValidator)
    {
        _certificationWriteRepository = certificationWriteRepository;
        _certificationValidator = certificationValidator;
    }

    public void Handle(CreateCertificationCommand cmd)
    {
        var aggregate = new CertificationAggregate(cmd);
        // validate
        _certificationWriteRepository.Save(aggregate);
    }

    public void Handle(UpdateCertificationCommand cmd)
    {
        var aggregate = _certificationWriteRepository.GetById(cmd.Id);
        _certificationValidator.CustomValidateDomainAndThrow(aggregate);

        aggregate.Change(cmd);
        _certificationWriteRepository.Save(aggregate);
        
    }
}