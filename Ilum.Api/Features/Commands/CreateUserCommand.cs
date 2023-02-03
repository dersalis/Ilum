using System.Linq;
using Ilum.Api.Context;
using Ilum.Api.Models;
using Ilum.Api.Shared;
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
    public CreateUserCommandHandler(IIlumContext ilumContext) : base(ilumContext)
    { }

    public async Task<Response> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        User user = await _ilumContext.Users.Where(u => u.Id == 1).FirstOrDefaultAsync();
        if (user is null) return Response.Failure("Brak użytkownika.");

        User userByLogin = await _ilumContext.Users.Where(u => u.Login == request.Login).FirstOrDefaultAsync();
        if (userByLogin is not null) return Response.Failure("Użytkownik o podanym loginie już istnieje.");

        if (!request.NewPassword.Equals(request.RepeatedPassword)) return Response.Failure("Podane hasła są różne.");

        Department department = await _ilumContext.Departments.Where(d => d.IsActive == true && d.Id == request.DepartmentId).FirstOrDefaultAsync();
        if (department is null) return Response.Failure("Brak działu o danum Id.");

        User newUser = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Login = request.Login,
            CurrentPassword = request.NewPassword,
            Department = department,
            IsActive = true,
            CreateDate = DateTime.Now,
            CreateByUser = user
        };

        _ilumContext.Users.Add(newUser);
        int resultId = await _ilumContext.SaveChangesAsync();

        return Response.Success(resultId);
    }
}