using LearnCert.Domain.Domains.Certification.Write.States;
using LearnCert.Domain.Infrastructure.Persistence;
using LearnCert.Domain.Infrastructure.Persistence.QueryHandlers;

namespace LearnCert.Domain.Domains.Book.Read.QueryHandlers;

public interface ICertificationFlatQueryHandler : IBaseQueryHandler<CertificationFlatModel>
{
}

public class CertificationFlatQueryHandler : BaseQueryHandler<CertificationFlatModel>, ICertificationFlatQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public CertificationFlatQueryHandler(IUnitOfWork unitOfWork): base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

}