using LearnCert.Domain;
using LearnCert.Domain.Domains.Book;
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
        return _bookReadRepository.GetBooks().ToList();
    }

    [HttpPut]
    public IList<Book> Put()
    {
        var book = _bookReadRepository.GetBooks().ToList();
        book[0].Title = "Teste";

        _bookReadRepository.Update(book[0]);

        return _bookReadRepository.GetBooks().ToList();
    }
        
}