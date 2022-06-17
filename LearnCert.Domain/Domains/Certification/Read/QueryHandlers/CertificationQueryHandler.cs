using LearnCert.Domain.Domains.Certification.Write.States;
using LearnCert.Domain.Infrastructure.Persistence;
using LearnCert.Domain.Infrastructure.Persistence.QueryHandlers;

namespace LearnCert.Domain.Domains.Book.Read.QueryHandlers;

public interface ICertificationQueryHandler : IBaseQueryHandler<CertificationModel>
{
    bool Exists(string title);
}

public class CertificationQueryHandler : BaseQueryHandler<CertificationModel>, ICertificationQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public CertificationQueryHandler(IUnitOfWork unitOfWork): base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public bool Exists(string title)
    {
        return _unitOfWork.Query<CertificationModel>().Any(x => x.Title == title);
    }
}