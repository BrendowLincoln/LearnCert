using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain;

public interface IBookReadRepository
{
    IQueryable<Book> GetBooks();
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
}