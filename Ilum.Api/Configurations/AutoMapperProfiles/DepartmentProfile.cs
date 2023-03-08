using System;
using AutoMapper;
using Ilum.Api.Dtos;
using Ilum.Api.Models;
using Ilum.Domain.User;

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

