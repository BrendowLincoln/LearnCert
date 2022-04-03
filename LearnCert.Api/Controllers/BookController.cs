using FluentValidation;
using LearnCert.API.DTO;
using LearnCert.Domain.Domains.Book;
using LearnCert.Domain.Infrastructure.CQRS;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]/[action]")]
public class BookController : ControllerBase
{

    private readonly IBookWriteRepository _bookWriteRepository;
    private readonly IBookReadRepository _bookReadRepository;
    private readonly IBookValidator _bookValidator;
    private readonly ICommandRouter _commandRouter;
        
    public BookController(
        IBookReadRepository bookReadRepository, 
        IBookWriteRepository bookWriteRepository, 
        IBookValidator bookValidator, 
        ICommandRouter commandRouter)
    {
        _bookReadRepository = bookReadRepository;
        _bookWriteRepository = bookWriteRepository;
        _bookValidator = bookValidator;
        
        _commandRouter = commandRouter;
        
    }
        
    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult Show(Guid id)
    {
        var book = _bookReadRepository.GetById(id);
        _bookValidator.ValidateDomainAndThrow(book);
        return Ok(book);
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return Ok(_bookReadRepository.GetBooks().ToList());
    }
    
    [HttpPost]
    public IActionResult Create([FromBody] CreateBookCommand command)
    {
        _commandRouter.Send(command);
        return Created(new Uri($"{Request.Path}/{command.Id}", UriKind.Relative), command);
    }

    [HttpPut]
    public IActionResult Update([FromBody] ChangeBookCommand command)
    {
        _commandRouter.Send(command);
        return Accepted();
    }
    
    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete(Guid id)
    {
        var book = _bookReadRepository.GetById(id);
        _bookValidator.ValidateDomainAndThrow(book);
        _bookWriteRepository.Delete(book);
        return NoContent();
    }
}