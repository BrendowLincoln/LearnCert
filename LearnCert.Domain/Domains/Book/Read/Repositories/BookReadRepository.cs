using LearnCert.Domain.Infrastructure.Persistence;
using ILogger = Serilog.ILogger;

namespace LearnCert.Domain.Domains.Book;

public interface IBookReadRepository : IBaseReadRepository<BookState>
{
    BookState GetById(Guid id);
    IQueryable<BookState> GetBooks();
    bool Exists(string title);
}

public class BookReadRepository : BaseReadRepository<BookState>, IBookReadRepository
{

    private readonly ILogger _logger;
    private readonly IUnitOfWork _unitOfWork;
    
    public BookReadRepository(IUnitOfWork unitOfWork, ILogger logger) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public BookState GetById(Guid id)
    {
        return _unitOfWork.GetById<BookState>(id);
    }

    public IQueryable<BookState> GetBooks()
    {
        _logger.Information("Getting books");
        return _unitOfWork.Query<BookState>();
    }

    
    public bool Exists(string title)
    {
        return _unitOfWork.Query<BookState>().Any(x => x.Title == title);
    }
}