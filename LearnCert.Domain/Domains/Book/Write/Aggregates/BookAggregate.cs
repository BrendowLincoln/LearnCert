using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Domains.Book;

public interface IBookAggregate : IAggregate<BookState>
{
    void Change(ChangeBookCommand cmd);
}

public class BookAggregate: BaseAggregate<BookState>, IBookAggregate
{

    public BookAggregate(BookState state)
    {
        State = state;
    }

    public BookAggregate(CreateBookCommand cmd)
    {
        State = new BookState
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