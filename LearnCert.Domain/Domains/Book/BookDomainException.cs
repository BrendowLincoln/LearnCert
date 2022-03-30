using LearnCert.Domain.Infrastructure.Exception;

namespace LearnCert.Domain.Domains.Book;

public class BookDomainException : DomainException
{
    public BookDomainException(string message = null) : base(message)
    {
    }
}