using FluentValidation;
using LearnCert.API.DTO;
using LearnCert.Domain.Domains.Book;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]/[action]")]
public class BookController : ControllerBase
{

    private readonly IBookRepository _bookRepository;
    private readonly IBookReadRepository _bookReadRepository;
    private readonly IBookValidator _bookValidator;
        
    public BookController(
        IBookReadRepository bookReadRepository, 
        IBookRepository bookRepository, 
        IBookValidator bookValidator)
    {
        _bookReadRepository = bookReadRepository;
        _bookRepository = bookRepository;
        _bookValidator = bookValidator;
    }
        
    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult Show(Guid id)
    {
        var book = _bookReadRepository.GetById(id);
        if (book == null)
        {
            return NotFound("Book not found");
        }

        return Ok(book);
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return Ok(_bookReadRepository.GetBooks().ToList());
    }
    
    [HttpPost]
    public IActionResult Create([FromBody] BookDTO request)
    {
        var book = new Book 
        {
            Title = request.Title
        };
        
        _bookValidator.ValidateAndThrow(book);
        _bookRepository.Save(book);

        return Created(new Uri($"{Request.Path}/{book.Id}", UriKind.Relative), book);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public IActionResult Update(Guid id, [FromBody] BookDTO request)
    {
        var book = _bookReadRepository.GetById(id);
        _bookValidator.ValidateDomainAndThrow(book);

        book.Title = request.Title;
        _bookValidator.ValidateAndThrow(book);
        
        _bookRepository.Update(book);

        return Accepted();
    }
    
    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(Guid id)
    {
        var book = _bookReadRepository.GetById(id);

        if (book == null)
        {
            return NotFound("Book not found");
        }

        _bookRepository.Delete(book);

        return NoContent();
    }
}