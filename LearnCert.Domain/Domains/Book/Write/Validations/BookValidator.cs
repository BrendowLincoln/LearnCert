using FluentValidation;
using LearnCert.Domain.Infrastructure.Validation;

namespace LearnCert.Domain.Domains.Book;

public interface IBookValidator : IDomainValidator<IBookAggregate>
{
}

public class BookValidator : DomainValidator<IBookAggregate>, IBookValidator
{

    private readonly IBookReadRepository _bookReadRepository;

    public BookValidator(IBookReadRepository bookReadRepository)
    {
        _bookReadRepository = bookReadRepository;

        RuleFor(x => x.GetState().Title)
            .NotEmpty().WithMessage(BookExceptionCodes.TitleNotInformed)
            .Length(2, 10).WithMessage(BookExceptionCodes.TitleMustBeGreaterThanTwoAndLessThanTen)
            .Must(NotUsed).WithMessage(BookExceptionCodes.TitleAlreadyUsed);
    }

    private bool NotUsed(string title)
    {
        return !_bookReadRepository.Exists(title);
    }

    public void CustomValidateDomainAndThrow(object aggregate)
    {
        if (aggregate == null)
        {
            throw new DomainException<IBookAggregate>(BookExceptionCodes.BookNotFound);
        }
    }
}