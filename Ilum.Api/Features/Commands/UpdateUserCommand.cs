using AutoMapper;
using Ilum.Api.Models;
using Ilum.Api.Shared;
using Ilum.Domain.Context;
using Ilum.Domain.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
    public UpdateUserCommandHandler(IIlumContext ilumContext, IMapper mapper) : base(ilumContext, mapper)
    {}

    public async Task<Response> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        User modifiedBy = await _ilumContext.Users.Where(u => u.Id == 1).FirstOrDefaultAsync();
        if (modifiedBy is null) return Response.Failure("Brak użytkownika.");

        User userToUpdate = await _ilumContext.Users.Where(u => u.Id == request.Id).FirstOrDefaultAsync();
        if (userToUpdate is null) return Response.Failure($"Użytkownik o Id = {request.Id} nie istnieje.");

        if (!request.NewPassword.Equals(request.RepeatedPassword)) return Response.Failure("Podane hasła są różne.");

        if (BCrypt.Net.BCrypt.Verify(request.NewPassword, userToUpdate.LastPassword)) return Response.Failure("To hasło było już użyte - wybierz inne!");

        Department department = await _ilumContext.Departments.Where(d => d.IsActive == true && d.Id == request.DepartmentId).FirstOrDefaultAsync();
        if (department is null) return Response.Failure($"Brak działu o Id = {request.DepartmentId}.");

        userToUpdate.FirstName = request.FirstName;
        userToUpdate.LastName = request.LastName;
        userToUpdate.LastPassword = userToUpdate.CurrentPassword;
        userToUpdate.CurrentPassword = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
        userToUpdate.Department = department;
        userToUpdate.ModifiedByUser = modifiedBy;
        userToUpdate.ModifiedDate = DateTime.Now;

        await _ilumContext.SaveChangesAsync();

        return Response.Success(request.Id);
    }
}