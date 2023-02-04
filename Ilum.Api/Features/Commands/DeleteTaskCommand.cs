﻿using Ilum.Api.Context;
using Ilum.Api.Models;
using Ilum.Api.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ilum.Api.Features.Commands;

public class DeleteTaskCommand : IRequest<Response>
{
	public int Id { get; set; }
}


public class DeleteTaskCommandHandler : BaseHandler, IRequestHandler<DeleteTaskCommand, Response>
{
    public DeleteTaskCommandHandler(IIlumContext ilumContext) : base(ilumContext)
    { }

    public async Task<Response> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        User user = await _ilumContext.Users.Where(u => u.Id == 1).FirstOrDefaultAsync();
        if (user is null) return Response.Failure("Brak użytkownika.");

        Models.Task taskToUpdate = await _ilumContext.Tasks.Where(t => t.Id == request.Id).FirstOrDefaultAsync();
        if (taskToUpdate is null) return Response.Failure($"Zadanie o Id = {request.Id} nie istnieje.");

        taskToUpdate.IsActive = false;
        taskToUpdate.ModifiedByUser = user;
        taskToUpdate.ModifiedDate = DateTime.Now;

        await _ilumContext.SaveChangesAsync();

        return Response.Success(request.Id);
    }
}