using System;
using Ilum.Api.Features.Commands;
using Ilum.Api.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ilum.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : BaseController
{
    public UsersController(IMediator mediator) : base(mediator)
    { }

    [HttpGet]
	public async Task<IActionResult> Get()
	{
		return Ok(await _mediator.Send(new GetAllUsersQuery()));
	}


	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(int id)
	{
		return Ok(await _mediator.Send(new GetUserByIdQuery() { Id = id }));
	}


	[HttpPost]
	public async Task<IActionResult> Createt([FromBody] CreateUserCommand command)
	{
		return Ok(await _mediator.Send(command));
	}


	[HttpPut("{id}")]
	public async Task<IActionResult> Update(int id, [FromBody] UpdateUserCommand command)
	{
		if (id != command.Id) return BadRequest();

		return Ok(await _mediator.Send(command));
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		return Ok(await _mediator.Send(new DeleteUserCommand() { Id = id }));
	}
}

