using System;
using Ilum.Api.Context;
using Ilum.Api.Models;
using Ilum.Api.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ilum.Api.Features.Commands;

public class UpdateTaskCommand : IRequest<Response>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Progress { get; set; }
    public string Comment { get; set; }
    public Enums.TaskStatus Status { get; set; }
    public Enums.TaskPriority Priority { get; set; }
    public int ResponsibleUserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime PlannedFinishDate { get; set; }
    public DateTime FinishDate { get; set; }
}


public class UpdateTaskCommandHandler : BaseHandler, IRequestHandler<UpdateTaskCommand, Response>
{
    public UpdateTaskCommandHandler(IIlumContext ilumContext) : base(ilumContext)
    { }

    public async Task<Response> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        User user = await _ilumContext.Users.Where(u => u.Id == 1).FirstOrDefaultAsync();
        if (user is null) return Response.Failure("Brak użytkownika.");

        User responsibleUser = await _ilumContext.Users.Where(u => u.Id == request.ResponsibleUserId).FirstOrDefaultAsync();
        if (responsibleUser is null) return Response.Failure($"Brak użytkownika o id = {request.ResponsibleUserId}.");

        Models.Task taskToUpdate = await _ilumContext.Tasks.Where(t => t.Id == request.Id).FirstOrDefaultAsync();
        if (taskToUpdate is null) return Response.Failure($"Zadanie o Id = {request.Id} nie istnieje.");

        taskToUpdate.Name = request.Name;
        taskToUpdate.Description = request.Description;
        taskToUpdate.Progress = request.Progress;
        taskToUpdate.Comment = request.Comment;
        taskToUpdate.Status = request.Status;
        taskToUpdate.Priority = request.Priority;
        taskToUpdate.ResponsibleUser = responsibleUser;
        taskToUpdate.StartDate = request.StartDate;
        taskToUpdate.PlannedFinishDate = request.PlannedFinishDate;
        taskToUpdate.FinishDate = request.FinishDate;
        taskToUpdate.ModifiedByUser = user;
        taskToUpdate.ModifiedDate = DateTime.Now;

        await _ilumContext.SaveChangesAsync();

        return Response.Success(request.Id);
    }
}