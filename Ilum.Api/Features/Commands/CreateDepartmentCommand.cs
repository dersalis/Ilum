using Ilum.Api.Shared;
using MediatR;

namespace Ilum.Api.Features.Commands;

public class CreateDepartmentCommand : IRequest<Response>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int LeaderId { get; set; }
}

