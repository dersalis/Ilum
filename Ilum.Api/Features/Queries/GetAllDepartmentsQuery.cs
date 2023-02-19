using System;
using AutoMapper;
using Ilum.Api.Context;
using Ilum.Api.Dtos;
using Ilum.Api.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ilum.Api.Features.Queries
{
	public class GetAllDepartmentsQuery : IRequest<IEnumerable<GetDepartmentDto>>
	{ }

    public class GetAllDepartmentsQueryHandler : BaseHandler, IRequestHandler<GetAllDepartmentsQuery, IEnumerable<GetDepartmentDto>>
    {
        public GetAllDepartmentsQueryHandler(IIlumContext ilumContext, IMapper mapper) : base(ilumContext, mapper)
        { }

        public async Task<IEnumerable<GetDepartmentDto>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Department> departments = await _ilumContext.Departments.ToListAsync(cancellationToken);

            if (departments == null) return null;

            return _mapper.Map<IEnumerable<GetDepartmentDto>>(departments);
        }
    }
}