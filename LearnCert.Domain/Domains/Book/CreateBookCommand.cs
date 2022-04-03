using LearnCert.Domain.Infrastructure.CQRS;

namespace LearnCert.Domain.Domains.Book;

public class CreateBookCommand : ICommand
{
    public Guid Id { get; set; }
    public string Title { get; set; }
}