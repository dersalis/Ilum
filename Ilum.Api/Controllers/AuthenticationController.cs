using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ilum.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : BaseController
{
    public AuthenticationController(IMediator mediator) : base(mediator)
    { }

    [HttpPost("login")]
    public IActionResult Login()
    {
        return Unauthorized();
    }
}

