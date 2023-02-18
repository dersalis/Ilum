using AutoMapper;
using Ilum.Api.Dtos;
using Ilum.Api.Models;

namespace Ilum.Api.Configurations.AutoMapperProfiles;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<User, GetUserDto>();
	}
}

