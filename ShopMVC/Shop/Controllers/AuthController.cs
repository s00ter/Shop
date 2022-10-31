using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers;

[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Auth(AuthDto body)
    {
        //TODO: validate and return token
        return Ok();
    }
}