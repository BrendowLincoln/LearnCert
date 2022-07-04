using FluentValidation;
using LearnCert.Domain.Domains.Book.Read.QueryHandlers;
using LearnCert.Domain.Domains.Certification;
using LearnCert.Domain.Domains.Certification.Write.Aggregates;
using LearnCert.Domain.Infrastructure.Validation;

namespace LearnCert.Domain.Domains.Certification;

public interface ICertificationValidator : IDomainValidator<ICertificationAggregate>
{
}

public class CertificationValidator : DomainValidator<ICertificationAggregate>, ICertificationValidator
{

    private readonly ICertificationQueryHandler _certificationQueryHandler;

    public CertificationValidator(ICertificationQueryHandler certificationQueryHandler)
    {
        _certificationQueryHandler = certificationQueryHandler;

        RuleFor(x => x.GetState().Title)
            .NotEmpty().WithMessage(CertificationExceptionCodes.TitleNotInformed);
    }

    private bool NotUsed(string title)
    {
        return !_certificationQueryHandler.Exists(title);
    }

    public void CustomValidateDomainAndThrow(object aggregate)
    {
        if (aggregate == null)
        {
            throw new DomainException<ICertificationAggregate>(CertificationExceptionCodes.NotFound);
        }
    }
}