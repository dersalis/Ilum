using System;
using AutoMapper;
using Ilum.Api.Context;
using Ilum.Api.Dtos;
using Ilum.Api.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ilum.Api.Features.Queries;

public class GetAllTaskQuery : IRequest<IEnumerable<GetTaskDto>>
{ }

public class GetAllTaskQueryHandler : BaseHandler, IRequestHandler<GetAllTaskQuery, IEnumerable<GetTaskDto>>
{
    public GetAllTaskQueryHandler(IIlumContext ilumContext, IMapper mapper) : base(ilumContext, mapper)
    { }

    public async Task<IEnumerable<GetTaskDto>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Models.Task> tasks = await _ilumContext.Tasks.ToListAsync(cancellationToken);

        if (tasks is null) return null;

        return _mapper.Map<IEnumerable<GetTaskDto>>(tasks);
    }
}