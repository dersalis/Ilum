using AutoMapper;
using Ilum.Api.Context;
using Ilum.Api.Dtos;
using Ilum.Api.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ilum.Api.Features.Queries;

public class GetUserByIdQuery : IRequest<GetUserDto>
{
	public int Id { get; set; }
}

public class GetUserByIdQueryHandler : BaseHandler, IRequestHandler<GetUserByIdQuery, GetUserDto>
{
    public GetUserByIdQueryHandler(IIlumContext ilumContext, IMapper mapper) : base(ilumContext, mapper)
    {}

    public async Task<GetUserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        User user = await _ilumContext.Users.Where(u => u.Id == request.Id).FirstOrDefaultAsync();

        if (user is null) return null;

        //GetUserDto userDto = new()
        //{
        //    Id = user.Id,
        //    FirstName = user.FirstName,
        //    LastName = user.LastName,
        //    Email = user.Email,
        //    Login = user.Login,
        //    DepartmentId = user.Department?.Id,
        //    DepartmentName = user.Department?.Name,
        //};

        //return userDto;

        return _mapper.Map<GetUserDto>(user);
    }
}