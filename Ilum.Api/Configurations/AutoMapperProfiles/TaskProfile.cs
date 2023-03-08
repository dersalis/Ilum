using System;
using AutoMapper;
using Ilum.Api.Dtos;

namespace Ilum.Api.Configurations.AutoMapperProfiles
{
	public class TaskProfile : Profile
	{
		public TaskProfile()
		{
			CreateMap<Domain.Task.Task, GetTaskDto>();
		}
	}
}

