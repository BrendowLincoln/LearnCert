using LearnCert.Domain.Domains.Book;
using LearnCert.Domain.Domains.Book.Read.QueryHandlers;
using LearnCert.Domain.Infrastructure.CQRS;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]/[action]")]
public class BookController : ControllerBase
{

    private readonly IBookValidator _bookValidator;
    private readonly ICommandRouter _commandRouter;
    private readonly IBookQueryHandler _bookQueryHandler;
        
    public BookController(
        IBookValidator bookValidator, 
        ICommandRouter commandRouter, 
        IBookQueryHandler bookQueryHandler)
    {
        _bookValidator = bookValidator;
        
        _commandRouter = commandRouter;
        _bookQueryHandler = bookQueryHandler;
    }
        
    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult Show(Guid id)
    {
        var book = _bookQueryHandler.GetById(id);
        _bookValidator.CustomValidateDomainAndThrow(book);
        return Ok(book);
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return Ok(_bookQueryHandler.Query());
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
    public IActionResult Delete([FromBody] DeleteBookCommand command)
    {
        _commandRouter.Send(command);
        return NoContent();
    }
}