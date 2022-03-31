using LearnCert.API.Infrastructure;
using LearnCert.Domain.Domains.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnCert.API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class LoginController : ControllerBase
{
    [HttpPost]
    public IActionResult Login([FromBody] User user)
    {
        var token = new TokenService().GenerateToken(user);
        return Ok(new
        {
            user,
            token
        });
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Anonymous() => Ok("Anonymous");

    [HttpGet]
    [Authorize]
    public IActionResult Authenticated() => Ok($"Authenticated: {User.Identity.Name}");
    
    [HttpGet]
    [Authorize(Roles = "role_basic, role_advanced")]
    public IActionResult AllRoles() => Ok($"User: {User.Identity.Name} with All Roles");
    
    [HttpGet]
    [Authorize(Roles = "role_advanced")]
    public IActionResult RoleAdvanced() => Ok($"User: {User.Identity.Name} with Advanced Role");
}