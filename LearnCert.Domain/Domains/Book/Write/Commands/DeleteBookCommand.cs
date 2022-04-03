using LearnCert.Domain.Infrastructure.CQRS;

namespace LearnCert.Domain.Domains.Book;

public class DeleteBookCommand : ICommand
{
    public Guid Id { get; set; }
}