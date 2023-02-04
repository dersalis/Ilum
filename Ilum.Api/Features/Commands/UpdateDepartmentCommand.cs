using System;
using Ilum.Api.Context;
using Ilum.Api.Models;
using Ilum.Api.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ilum.Api.Features.Commands;

public class UpdateDepartmentCommand : IRequest<Response>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int LeaderId { get; set; }
}


public class UpdateDepartmentCommandHandler : BaseHandler, IRequestHandler<UpdateDepartmentCommand, Response>
{
    public UpdateDepartmentCommandHandler(IIlumContext ilumContext) : base(ilumContext)
    { }

    public async Task<Response> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        User user = await _ilumContext.Users.Where(u => u.Id == 1).FirstOrDefaultAsync();
        if (user is null) return Response.Failure("Brak użytkownika.");

        Department departmentExist = await _ilumContext.Departments.Where(d => d.Name == request.Name && d.Id != request.Id).FirstOrDefaultAsync();
        if (departmentExist is not null) return Response.Failure("Biuro o danej nazwie już istnieje");

        Department departmentToUpdate = await _ilumContext.Departments.Where(d => d.Id == request.Id).FirstOrDefaultAsync();
        if (departmentToUpdate is null) return Response.Failure($"Biuro o Id = {request.Id} nie istnieje.");

        User leader = await _ilumContext.Users.Where(u => u.Id == request.LeaderId).FirstOrDefaultAsync();
        if (user is null) return Response.Failure($"Brak użytkownika o Id = {request.LeaderId}.");

        departmentToUpdate.Name = request.Name;
        departmentToUpdate.Description = request.Description;
        departmentToUpdate.Leader = leader;
        departmentToUpdate.ModifiedByUser = user;
        departmentToUpdate.ModifiedDate = DateTime.Now;

        await _ilumContext.SaveChangesAsync();

        return Response.Success(request.Id);
    }
}