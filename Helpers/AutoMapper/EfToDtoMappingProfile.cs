using API.Dtos.UserManager;
using API.Models;
using AutoMapper;

namespace API.Helpers.AutoMapper;
public class EfToDtoMappingProfile : Profile
{
    public EfToDtoMappingProfile()
    {
        // CreateMap<Sys_User, Sys_UserDto>();
    }
}