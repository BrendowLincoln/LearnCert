using FluentValidation;

namespace LearnCert.Domain.Infrastructure.Validation;

public interface IDomainValidator<TEntity> : IValidator<TEntity>, IEnumerable<IValidationRule>
{
    void ValidateDomainAndThrow(TEntity entity);
}

public class DomainValidator<TEntity> : AbstractValidator<TEntity>, IDomainValidator<TEntity>
{

    private const string NotFound = "NOT_FOUND";

    protected DomainValidator()
    {
        // Break on first error message
        CascadeMode = CascadeMode.StopOnFirstFailure;
    }

    public void ValidateDomainAndThrow(TEntity entity)
    {
        if (entity == null)
        {
            throw new DomainException(NotFound);
        }
    }

}