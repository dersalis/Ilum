using System;
using AutoMapper;
using Ilum.Api.Dtos;
using Ilum.Api.Models;

namespace Ilum.Api.Configurations.AutoMapperProfiles
{
	public class DepartmentProfile : Profile
	{
		public DepartmentProfile()
		{
			CreateMap<Department, GetDepartmentDto>();
		}
	}
}

