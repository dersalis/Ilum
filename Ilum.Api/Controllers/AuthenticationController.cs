using System;
using Ilum.Api.Features.Commands;
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
    public async Task<IActionResult> Login([FromBody] AuthenticationCommand command)
    {
        if (command is null || command.Email is null || command.Password is null || command.Email == string.Empty || command.Password == string.Empty)
            return BadRequest();

        var response = await _mediator.Send(command);
        if (response is not null) return Ok(response);

        return Unauthorized();
    }
}

