using AutoMapper;
using Ilum.Api.Context;
using Ilum.Api.Models;
using Ilum.Api.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ilum.Api.Features.Commands;

public class DeleteDepartmentCommand : IRequest<Response>
{
    public int Id { get; set; }
}


public class DeleteDepartmentCommandHandler : BaseHandler, IRequestHandler<DeleteDepartmentCommand, Response>
{
    public DeleteDepartmentCommandHandler(IIlumContext ilumContext, IMapper mapper) : base(ilumContext, mapper)
    { }

    public async Task<Response> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        User user = await _ilumContext.Users.Where(u => u.Id == 1).FirstOrDefaultAsync();
        if (user is null) return Response.Failure("Brak użytkownika.");

        Department departmentToUpdate = await _ilumContext.Departments.Where(d => d.Id == request.Id).FirstOrDefaultAsync();
        if (departmentToUpdate is null) return Response.Failure($"Biuro o Id = {request.Id} nie istnieje.");

        departmentToUpdate.IsActive = false;
        departmentToUpdate.ModifiedByUser = user;
        departmentToUpdate.ModifiedDate = DateTime.Now;

        await _ilumContext.SaveChangesAsync();

        return Response.Success(request.Id);
    }
}