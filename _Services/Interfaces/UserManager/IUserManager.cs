using API.Dtos.UserManager;
using API.Helpers.Utilities;
using API.Models;
using static API.Configurations.DependencyInjectionConfig;

namespace API._Services.Interfaces.UserManager;
[DependencyInjection(ServiceLifetime.Scoped)]
public interface IUserManager
{
    Task<PaginationUtility<Sys_User>> GetAll(PaginationParam pagination, UserManagerSearchParam param);
    Task<Sys_User?> GetById(int id);
    Task<Sys_User?> AddAndUpdateUser(Sys_User userObj);
}
