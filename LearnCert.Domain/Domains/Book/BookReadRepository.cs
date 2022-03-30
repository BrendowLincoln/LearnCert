using LearnCert.Domain.Infrastructure.Persistence;
using ILogger = Serilog.ILogger;

namespace LearnCert.Domain.Domains.Book;

public interface IBookReadRepository : IBaseReadRepository<Book>
{
    Book GetById(Guid id);
    IQueryable<Book> GetBooks();
    bool Exists(string title);
}

public class BookReadRepository : BaseReadRepository<Book>, IBookReadRepository
{

    private readonly ILogger _logger;
    private readonly IUnitOfWork _unitOfWork;
    
    public BookReadRepository(IUnitOfWork unitOfWork, ILogger logger) : base(unitOfWork)
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

    
    public bool Exists(string title)
    {
        return _unitOfWork.Query<Book>().Any(x => x.Title == title);
    }
}