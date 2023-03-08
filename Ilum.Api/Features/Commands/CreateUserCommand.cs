using AutoMapper;
using Ilum.Api.Context;
using Ilum.Api.Models;
using Ilum.Api.Shared;
using Ilum.Domain.User;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ilum.Api.Features.Commands;

public class CreateUserCommand : IRequest<Response>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }
    public string NewPassword { get; set; }
    public string RepeatedPassword { get; set; }
    public int DepartmentId { get; set; }
}


public class CreateUserCommandHandler : BaseHandler, IRequestHandler<CreateUserCommand, Response>
{
    public CreateUserCommandHandler(IIlumContext ilumContext, IMapper mapper) : base(ilumContext, mapper)
    { }

    public async Task<Response> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        User createdBy = await _ilumContext.Users.Where(u => u.Id == 1).FirstOrDefaultAsync();
        if (createdBy is null) return Response.Failure("Brak użytkownika.");

        User userByLogin = await _ilumContext.Users.Where(u => u.Login == request.Login || u.Email == request.Email).FirstOrDefaultAsync();
        if (userByLogin is not null) return Response.Failure("Użytkownik o podanym loginie lub e-mail już istnieje.");

        if (!request.NewPassword.Equals(request.RepeatedPassword)) return Response.Failure("Podane hasła są różne.");

        Department department = await _ilumContext.Departments.Where(d => d.IsActive == true && d.Id == request.DepartmentId).FirstOrDefaultAsync();
        if (department is null) return Response.Failure($"Brak działu o Id = {request.DepartmentId}.");

        User newUser = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Login = request.Login,
            CurrentPassword = BCrypt.Net.BCrypt.HashPassword(request.NewPassword),
            LastPassword = string.Empty,
            Department = department,
            IsActive = true,
            CreateDate = DateTime.Now,
            CreateByUser = createdBy
        };

        _ilumContext.Users.Add(newUser);
        int resultId = await _ilumContext.SaveChangesAsync();

        return Response.Success(resultId);
    }
}