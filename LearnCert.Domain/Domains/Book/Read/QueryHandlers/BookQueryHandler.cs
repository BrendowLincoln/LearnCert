using LearnCert.Domain.Domains.Book.Read.Models;
using LearnCert.Domain.Infrastructure.Persistence;
using LearnCert.Domain.Infrastructure.Persistence.QueryHandlers;

namespace LearnCert.Domain.Domains.Book.Read.QueryHandlers;

public interface IBookQueryHandler : IBaseQueryHandler<BookModel>
{
    bool Exists(string title);
}

public class BookQueryHandler : BaseQueryHandler<BookModel>, IBookQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public BookQueryHandler(IUnitOfWork unitOfWork): base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public bool Exists(string title)
    {
        return _unitOfWork.Query<BookModel>().Any(x => x.Title == title);
    }
}