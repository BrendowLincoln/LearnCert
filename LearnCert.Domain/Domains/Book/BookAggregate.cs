using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Domains.Book;

public interface IBookAggregate : IAggregate<Book>
{
    void Change(ChangeBookCommand cmd);
}

public class BookAggregate: BaseAggregate<Book>, IBookAggregate
{

    public BookAggregate(Book state)
    {
        State = state;
    }

    public BookAggregate(CreateBookCommand cmd)
    {
        State = new Book
        {
            Id = cmd.Id,
            Title = cmd.Title
        };
    }
    
    public void Change(ChangeBookCommand cmd)
    {
        State.Title = cmd.Title;
    }
}