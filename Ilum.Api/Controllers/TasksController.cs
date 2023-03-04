using Ilum.Api.Features.Commands;
using Ilum.Api.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ilum.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class TasksController : BaseController
{
    public TasksController(IMediator mediator) : base(mediator)
    { }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetAllTaskQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTaskCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTaskCommand command)
    {
        if (id != command.Id) return BadRequest();

        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _mediator.Send(new DeleteTaskCommand() { Id = id }));
    }
}

