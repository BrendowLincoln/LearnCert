using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Domains.Book.Read.Models;

public class BookModel : BaseModel
{
    public virtual string Title { get; set; }
}