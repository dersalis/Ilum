using System;
using Ilum.Api.Shared;
using MediatR;

namespace Ilum.Api.Features.Commands;

public class UpdateDepartmentCommand : IRequest<Response>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int LeaderId { get; set; }
}

