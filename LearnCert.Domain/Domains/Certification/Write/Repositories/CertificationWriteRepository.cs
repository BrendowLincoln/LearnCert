using LearnCert.Domain.Domains.Certification.Write.Aggregates;
using LearnCert.Domain.Domains.Certification.Write.States;
using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Domains.Certification.Write.Repositories;

public interface ICertificationWriteRepository : IBaseWriteRepository<CertificationState, CertificationAggregate>
{
    
}

public class CertificationWriteRepository : BaseWriteRepository<CertificationState, CertificationAggregate>, ICertificationWriteRepository
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRegisterProviderService _registerProviderService;
    
    public CertificationWriteRepository(IUnitOfWork unitOfWork, IRegisterProviderService registerProviderService) : base(unitOfWork, registerProviderService)
    {
        _unitOfWork = unitOfWork;
        _registerProviderService = registerProviderService;
    }
}