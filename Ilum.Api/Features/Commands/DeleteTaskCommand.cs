using System;
using Ilum.Api.Shared;
using MediatR;

namespace Ilum.Api.Features.Commands;

public class DeleteTaskCommand : IRequest<Response>
{
	public int Id { get; set; }
}

