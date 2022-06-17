using LearnCert.Domain.Domains.Book.Read.QueryHandlers;
using LearnCert.Domain.Domains.Certification.Write.Commands;
using LearnCert.Domain.Infrastructure.CQRS;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]/[action]")]
public class CertificationController : ControllerBase
{

    private readonly ICommandRouter _commandRouter;
    private readonly ICertificationQueryHandler _certificationQueryHandler;
    private readonly ICertificationFlatQueryHandler _certificationFlatQueryHandler;
        
    public CertificationController(ICommandRouter commandRouter, 
        ICertificationQueryHandler certificationQueryHandler,
        ICertificationFlatQueryHandler certificationFlatQueryHandler)
    {
        _commandRouter = commandRouter;
        _certificationQueryHandler = certificationQueryHandler;
        _certificationFlatQueryHandler = certificationFlatQueryHandler;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return Ok(_certificationFlatQueryHandler.Query());
    }
    
    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult Show(Guid id)
    {
        var certification = _certificationQueryHandler.GetById(id);
        return Ok(certification);
    }
        
    [HttpPost]
    public IActionResult Save([FromBody] CreateCertificationCommand command)
    {
        _commandRouter.Send(command);
        return Created(new Uri($"{Request.Path}/{command.Id}", UriKind.Relative), command);
    }

  
}