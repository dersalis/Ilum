using System;
using Ilum.Api.Context;
using Ilum.Api.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ilum.Api.Features.Queries;

public class GetUserByIdQuery : IRequest<User>
{
	public int Id { get; set; }
}

public class GetUserByIdQueryHandler : BaseHandler, IRequestHandler<GetUserByIdQuery, User>
{
    public GetUserByIdQueryHandler(IIlumContext ilumContext) : base(ilumContext)
    { }

    public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        User user = await _ilumContext.Users.Where(u => u.Id == request.Id).FirstOrDefaultAsync();

        if (user is null) return null;

        return user;
    }
}