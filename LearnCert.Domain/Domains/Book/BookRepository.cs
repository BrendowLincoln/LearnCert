using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Domains.Book;

public interface IBookRepository : IBaseRepository<Book>
{
    
}

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    private readonly IUnitOfWork _unitOfWork;
    
    public BookRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
}