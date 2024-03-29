using API.Dtos.UserManager;
using API.Models;
using AutoMapper;

namespace API.Helpers.AutoMapper;
public class DtoToEfMappingProfile : Profile
{
    public DtoToEfMappingProfile()
    {
        CreateMap<Sys_User, Sys_UserDto>();
    }
}
