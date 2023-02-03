using System;
using Ilum.Api.Shared;
using MediatR;

namespace Ilum.Api.Features.Commands;

public class UpdateUserCommand : IRequest<Response>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }
    public string NewPassword { get; set; }
    public string RepeatedPassword { get; set; }
    public int DepartmentId { get; set; }
}

