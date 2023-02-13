using System;
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
        public GetAllDepartmentsQueryHandler(IIlumContext ilumContext) : base(ilumContext)
        { }

        public async Task<IEnumerable<GetDepartmentDto>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Department> departments = await _ilumContext.Departments.ToListAsync(cancellationToken);

            if (departments is null) return null;

            return departments.Select(d => new GetDepartmentDto()
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                //LeaderId = d.Leader.Id,
                //LeaderName = $"{d.Leader.FirstName} {d.Leader.LastName}",
            });
        }
    }
}