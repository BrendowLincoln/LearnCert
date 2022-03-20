using LearnCert.Domain;
using LearnCert.Domain.Domains.Book;
using Microsoft.AspNetCore.Mvc;

[Route("Book")]
public class BookController : ControllerBase
{

    private readonly IBookRepository _bookRepository;
    private readonly IBookReadRepository _bookReadRepository;
        
    public BookController(IBookReadRepository bookReadRepository, IBookRepository bookRepository)
    {
        _bookReadRepository = bookReadRepository;
        _bookRepository = bookRepository;
    }
        
    [HttpGet]
    [Route("Index")]
    public IList<Book> Index()
    {
        return _bookReadRepository.GetBooks().ToList();
    }

    [HttpPut]
    public IList<Book> Put()
    {
        var book = _bookReadRepository.GetBooks().ToList();
        book[0].Title = "Teste";

        _bookRepository.Update(book[0]);

        return _bookReadRepository.GetBooks().ToList();
    }
        
}