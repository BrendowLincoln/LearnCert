using LearnCert.Domain.Domains.Certification.Write.Commands;
using LearnCert.Domain.Infrastructure.CQRS;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]/[action]")]
public class CertificationController : ControllerBase
{

    private readonly ICommandRouter _commandRouter;
        
    public CertificationController(ICommandRouter commandRouter)
    {
        _commandRouter = commandRouter;
    }
        
    [HttpPost]
    public IActionResult Create([FromBody] CreateCertificationCommand command)
    {
        _commandRouter.Send(command);
        return Created(new Uri($"{Request.Path}/{command.Id}", UriKind.Relative), command);
    }

  
}