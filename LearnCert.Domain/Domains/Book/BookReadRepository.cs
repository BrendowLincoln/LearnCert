using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Domains.Book;

public interface IBookReadRepository
{
    IQueryable<Book> GetBooks();
    void Update(Book book);
}

public class BookReadRepository : IBookReadRepository
{

    private readonly IUnitOfWork _unitOfWork;
    
    public BookReadRepository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public IQueryable<Book> GetBooks()
    {
        return _unitOfWork.Query<Book>();
    }

    public void Update(Book book)
    {
        _unitOfWork.Merge(book);
    }
}