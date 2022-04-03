using FluentValidation;

namespace LearnCert.Domain.Infrastructure.Validation;

public interface IDomainValidator<TAggregate> : IValidator<TAggregate>, IEnumerable<IValidationRule>
{
    void CustomValidateDomainAndThrow(object entity);
}

public class DomainValidator<TAggregate> : AbstractValidator<TAggregate>, IDomainValidator<TAggregate>
{

    private const string NotFound = "NOT_FOUND";

    protected DomainValidator()
    {
        // Break on first error message
        CascadeMode = CascadeMode.StopOnFirstFailure;
    }
    
    public void CustomValidateDomainAndThrow(object entity)
    {
        if (entity == null)
        {
            throw new DomainException<TAggregate>(NotFound);
        }
    }

}