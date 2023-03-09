using AutoMapper;
using Ilum.Api.Models;
using Ilum.Api.Shared;
using Ilum.Domain.Context;
using Ilum.Domain.User;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ilum.Api.Features.Commands;

public class DeleteUserCommand : IRequest<Response>
{
    public int Id { get; set; }
}


public class DeleteUserCommandHandler : BaseHandler, IRequestHandler<DeleteUserCommand, Response>
{
    public DeleteUserCommandHandler(IIlumContext ilumContext, IMapper mapper) : base(ilumContext, mapper)
    { }

    public async Task<Response> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        User user = await _ilumContext.Users.Where(u => u.Id == 1).FirstOrDefaultAsync();
        if (user is null) return Response.Failure("Brak użytkownika.");

        User userToUpdate = await _ilumContext.Users.Where(u => u.Id == request.Id).FirstOrDefaultAsync();
        if (user is null) return Response.Failure($"Użytkownik o Id = {request.Id} nie istnieje.");

        userToUpdate.IsActive = false;
        userToUpdate.ModifiedByUser = user;
        userToUpdate.ModifiedDate = DateTime.Now;

        await _ilumContext.SaveChangesAsync();

        return Response.Success(request.Id);
    }
}