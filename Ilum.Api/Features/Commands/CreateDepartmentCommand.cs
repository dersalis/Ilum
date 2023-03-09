using AutoMapper;
using Ilum.Api.Models;
using Ilum.Api.Shared;
using Ilum.Domain.Context;
using Ilum.Domain.User;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ilum.Api.Features.Commands;

public class CreateDepartmentCommand : IRequest<Response>
{
    public string Name { get; set; }
    public string Description { get; set; }
}


public class CreateDepartmentCommandHandler : BaseHandler, IRequestHandler<CreateDepartmentCommand, Response>
{
    public CreateDepartmentCommandHandler(IIlumContext ilumContext, IMapper mapper) : base(ilumContext, mapper)
    {}

    public async Task<Response> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        User user = await _ilumContext.Users.Where(u => u.Id == 1).FirstOrDefaultAsync();
        if (user is null) return Response.Failure("Brak użytkownika.");

        Department department = await _ilumContext.Departments.Where(d => d.Name == request.Name).FirstOrDefaultAsync();
        if (department is not null) return Response.Failure("Biuro o danej nazwie już istnieje");

        Department newDepartment = new()
        {
            Name = request.Name,
            Description = request.Description,
        };

        _ilumContext.Departments.Add(newDepartment);
        int resultId = await _ilumContext.SaveChangesAsync();

        return Response.Success(resultId);
    }
}