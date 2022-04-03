using LearnCert.Domain.Infrastructure;

namespace LearnCert.Domain.Domains.Book;

public class Book : BaseState
{
    public virtual string Title { get; set; }
}