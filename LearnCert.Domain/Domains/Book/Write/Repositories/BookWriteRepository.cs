using LearnCert.Domain.Infrastructure.Persistence;

namespace LearnCert.Domain.Domains.Book;

public interface IBookWriteRepository : IBaseWriteRepository<BookState, BookAggregate>
{
    
}

public class BookWriteRepository : BaseWriteRepository<BookState, BookAggregate>, IBookWriteRepository
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRegisterProviderService _registerProviderService;
    
    public BookWriteRepository(IUnitOfWork unitOfWork, IRegisterProviderService registerProviderService) : base(unitOfWork, registerProviderService)
    {
        _unitOfWork = unitOfWork;
        _registerProviderService = registerProviderService;
    }
}