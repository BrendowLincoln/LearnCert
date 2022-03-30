using FluentValidation;
using LearnCert.Domain.Infrastructure.Exception;

namespace LearnCert.Domain.Domains.Book;

public interface IBookValidator : IDomainValidator<Book>
{
}

public class BookValidator : DomainValidator<Book>, IBookValidator
{

    private readonly IBookReadRepository _bookReadRepository;

    public BookValidator(IBookReadRepository bookReadRepository)
    {
        _bookReadRepository = bookReadRepository;

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(BookExceptionCodes.TitleNotInformed)
            .Length(2, 10).WithMessage(BookExceptionCodes.TitleMustBeGreaterThanTwoAndLessThanFifty)
            .Must(NotUsed).WithMessage(BookExceptionCodes.TitleAlreadyUsed);
    }

    private bool NotUsed(string title)
    {
        return !_bookReadRepository.Exists(title);
    }

    public void ValidateDomainAndThrow(Book book)
    {
        if (book == null)
        {
            throw new BookDomainException(BookExceptionCodes.BookNotFound);
        }
    }
}