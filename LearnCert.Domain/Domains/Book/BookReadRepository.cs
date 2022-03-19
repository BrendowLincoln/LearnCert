using LearnCert.Domain.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;
using ILogger = Serilog.ILogger;

namespace LearnCert.Domain.Domains.Book;

public interface IBookReadRepository
{
    IQueryable<Book> GetBooks();
    void Update(Book book);
}

public class BookReadRepository : IBookReadRepository
{

    private readonly ILogger _logger;
    private readonly IUnitOfWork _unitOfWork;
    
    public BookReadRepository(IUnitOfWork unitOfWork, ILogger logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    
    public IQueryable<Book> GetBooks()
    {
        _logger.Information("Getting books");
        return _unitOfWork.Query<Book>();
    }

    public void Update(Book book)
    {
        _unitOfWork.Merge(book);
    }
}