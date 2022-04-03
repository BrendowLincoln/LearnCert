using FluentValidation;
using FluentValidation.Results;

namespace LearnCert.Domain.Infrastructure.Validation;

public static class DomainValidatorExtensions
{
    public static void ValidateDomainAndThrow<T>(this IValidator<T> validator, T instance) {
        ValidationResult result = validator.Validate(instance);
        if (result.Errors.Any())
        {
            throw new DomainException<T>(result.Errors.First().ErrorMessage);
        }
    }
}