using System;
using Ilum.Api.Features.Commands;
using Ilum.Api.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ilum.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : BaseController
{
    public DepartmentsController(IMediator mediator) : base(mediator)
    { }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _mediator.Send(new GetAllDepartmentsQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDepartmentCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpPut("{id: int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateDepartmentCommand command)
    {
        if (id != command.Id) return BadRequest();

        return Ok(await _mediator.Send(command));
    }

    [HttpDelete("{id: int}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _mediator.Send(new DeleteDepartmentCommand() { Id = id }));
    }
}

