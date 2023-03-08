using AutoMapper;
using Ilum.Api.Context;
using Ilum.Api.Dtos;
using Ilum.Api.Models;
using Ilum.Domain.User;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ilum.Api.Features.Queries;

public class GetAllUsersQuery : IRequest<IEnumerable<GetUserDto>>
{ }

public class GetAllUsersQueryHandler : BaseHandler, IRequestHandler<GetAllUsersQuery, IEnumerable<GetUserDto>>
{
    public GetAllUsersQueryHandler(IIlumContext ilumContext, IMapper mapper) : base(ilumContext, mapper)
    { }

    public async Task<IEnumerable<GetUserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<User> users = await _ilumContext.Users.ToListAsync(cancellationToken);

        if (users is null) return null;

        //return users.Select(u => new GetUserDto()
        //{
        //    Id = u.Id,
        //    FirstName = u.FirstName,
        //    LastName = u.LastName,
        //    Email = u.Email,
        //    Login = u.Login,
        //    DepartmentId = u.Department?.Id,
        //    DepartmentName = u.Department?.Name,
        //});

        return _mapper.Map<IEnumerable<GetUserDto>>(users);
    }
}
