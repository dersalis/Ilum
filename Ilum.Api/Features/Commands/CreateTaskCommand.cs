using AutoMapper;
using Ilum.Api.Context;
using Ilum.Api.Models;
using Ilum.Api.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ilum.Api.Features.Commands;

public class CreateTaskCommand : IRequest<Response>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Comment { get; set; }
    public Enums.TaskStatus Status { get; set; }
    public Enums.TaskPriority Priority { get; set; }
    public int ResponsibleUserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? PlannedFinishDate { get; set; }
}


public class CreateTaskCommandHandler : BaseHandler, IRequestHandler<CreateTaskCommand, Response>
{
    public CreateTaskCommandHandler(IIlumContext ilumContext, IMapper mapper) : base(ilumContext, mapper)
    { }

    public async Task<Response> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        User user = await _ilumContext.Users.Where(u => u.Id == 1).FirstOrDefaultAsync();
        if (user is null) return Response.Failure("Brak użytkownika.");

        User responsibleUser = await _ilumContext.Users.Where(u => u.Id == request.ResponsibleUserId).FirstOrDefaultAsync();
        if (responsibleUser is null) return Response.Failure($"Brak użytkownika o id = {request.ResponsibleUserId}.");

        Models.Task newTask = new()
        {
            Name = request.Name,
            Description = request.Description,
            Progress = 0,
            Comment = request.Comment,
            Status = request.Status,
            Priority = request.Priority,
            ResponsibleUser = responsibleUser,
            StartDate = request.StartDate,
            PlannedFinishDate = request.PlannedFinishDate
        };

        _ilumContext.Tasks.Add(newTask);
        int resultId = await _ilumContext.SaveChangesAsync();

        return Response.Success(resultId);
    }
}