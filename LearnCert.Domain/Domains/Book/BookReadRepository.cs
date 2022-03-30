using LearnCert.Domain.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;
using ILogger = Serilog.ILogger;

namespace LearnCert.Domain.Domains.Book;

public interface IBookReadRepository
{
    Book GetById(Guid id);
    IQueryable<Book> GetBooks();
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

    public Book GetById(Guid id)
    {
        return _unitOfWork.GetById<Book>(id);
    }

    public IQueryable<Book> GetBooks()
    {
        _logger.Information("Getting books");
        return _unitOfWork.Query<Book>();
    }

}