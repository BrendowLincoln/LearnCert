using LearnCert.Domain;
using Microsoft.AspNetCore.Mvc;


[Route("Book")]
public class BookController : ControllerBase
{

    private readonly IBookReadRepository _bookReadRepository;
        
    public BookController(IBookReadRepository bookReadRepository)
    {
        _bookReadRepository = bookReadRepository;
    }
        
    [HttpGet]
    [Route("Index")]
    public IList<Book> Index()
    {
        return _bookReadRepository.GetBooks().ToList();;
    }
        
}