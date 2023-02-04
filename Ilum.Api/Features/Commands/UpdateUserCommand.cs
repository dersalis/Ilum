using Ilum.Api.Context;
using Ilum.Api.Models;
using Ilum.Api.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ilum.Api.Features.Commands;

public class UpdateUserCommand : IRequest<Response>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NewPassword { get; set; }
    public string RepeatedPassword { get; set; }
    public int DepartmentId { get; set; }
}


public class UpdateUserCommandHandler : BaseHandler, IRequestHandler<UpdateUserCommand, Response>
{
    public UpdateUserCommandHandler(IIlumContext ilumContext) : base(ilumContext)
    { }

    public async Task<Response> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        User user = await _ilumContext.Users.Where(u => u.Id == 1).FirstOrDefaultAsync();
        if (user is null) return Response.Failure("Brak użytkownika.");

        User userToUpdate = await _ilumContext.Users.Where(u => u.Id == request.Id).FirstOrDefaultAsync();
        if (user is null) return Response.Failure($"Użytkownik o Id = {request.Id} nie istnieje.");

        if (!request.NewPassword.Equals(request.RepeatedPassword)) return Response.Failure("Podane hasła są różne.");

        Department department = await _ilumContext.Departments.Where(d => d.IsActive == true && d.Id == request.DepartmentId).FirstOrDefaultAsync();
        if (department is null) return Response.Failure($"Brak działu o Id = {request.DepartmentId}.");

        userToUpdate.FirstName = request.FirstName;
        userToUpdate.LastName = request.LastName;
        userToUpdate.LastPassword = userToUpdate.CurrentPassword;
        userToUpdate.CurrentPassword = request.NewPassword;
        userToUpdate.Department = department;
        userToUpdate.ModifiedByUser = user;
        userToUpdate.ModifiedDate = DateTime.Now;

        await _ilumContext.SaveChangesAsync();

        return Response.Success(request.Id);
    }
}