using LearnCert.Api.Infrastructure.Persistence;

namespace LearnCert.Api.Domain.Book;

public interface IBookReadRepository
{
    IQueryable<Api.Book> GetBooks();
}

public class BookReadRepository : IBookReadRepository
{

    private readonly IUnitOfWork _unitOfWork;
    
    public BookReadRepository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public IQueryable<Api.Book> GetBooks()
    {
        return _unitOfWork.Query<Api.Book>();
    }
}