using LearnCert.Domain.Infrastructure;

namespace LearnCert.Domain.Domains.Book;

public class BookState : BaseState
{
    public virtual string Title { get; set; }
}