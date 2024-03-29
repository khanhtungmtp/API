using API._Repositories;
using API._Services.Interfaces.UserManager;
using API.Dtos.Base;
using API.Dtos.UserManager;
using API.Helpers.Utilities;
using API.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace API._Services.Services.UserManager;

public class S_UserManager(IRepositoryAccessor repositoryAccessor, MapperConfiguration configMapper) : S_BaseServices(repositoryAccessor), IUserManager
{
    private readonly MapperConfiguration _configMapper = configMapper;
    public Task<Sys_User?> AddAndUpdateUser(Sys_User userObj)
    {
        throw new NotImplementedException();
    }

    public Task<AuthenticateResponse?> Authenticate(LoginDto model)
    {
        throw new NotImplementedException();
    }

    public async Task<PaginationUtility<Sys_User>> GetAll(PaginationParam pagination, UserManagerSearchParam param)
    {
        List<Sys_User> data = await GetData(param);
        return PaginationUtility<Sys_User>.Create(data, pagination.PageNumber, pagination.PageSize);
    }

    public async Task<List<Sys_User>> GetData(UserManagerSearchParam param)
    {
        ExpressionStarter<Sys_User> predicate = PredicateBuilder.New<Sys_User>(true);

        if (!string.IsNullOrWhiteSpace(param.UserName))
        {
            predicate.And(x => x.UserName.Contains(param.UserName));
        }

        if (!string.IsNullOrWhiteSpace(param.FullName))
        {
            predicate.And(x => x.FullName.Contains(param.FullName));
        }

        if (!string.IsNullOrWhiteSpace(param.Mobile))
        {
            predicate.And(x => x.Mobile != null && x.Mobile.Contains(param.Mobile));
        }

        if (!string.IsNullOrWhiteSpace(param.Email))
        {
            predicate.And(x => x.Email != null && x.Email.Contains(param.Email));
        }

        if (param.IsActive.HasValue)
        {
            predicate.And(x => x.IsActive == param.IsActive);
        }

        List<Sys_User> users = await _repositoryAccessor.Sys_User.FindAll(predicate, true).ToListAsync();
        List<Sys_User_Role> userRoles = await _repositoryAccessor.Sys_User_Role.FindAll(x => users.Select(a => a.Id).Contains(x.UserId), true).ToListAsync();
        List<Sys_UserDto>? list = await _repositoryAccessor.Sys_User.FindAll(true)
        .GroupJoin(_repositoryAccessor.Sys_User_Role.FindAll(true),
        user => user.Id, userRole => userRole.Id, (user, userRoles) => new { user, userRoles })
        .SelectMany(j => j.userRoles.DefaultIfEmpty(),
        (parent, userRoles) => new { parent.user, userRoles })
        .Join(_repositoryAccessor.Sys_Role.FindAll(true),
        temp => temp.userRoles != null ? temp.userRoles.RoleId : 0,
        role => role.Id,
        (temp, role) => new { temp.user, role })
        .Select(joined => new Sys_UserDto
        {
            Sys_User = joined.user,
            Sys_Role = joined.role
        }).ToListAsync();
        // List<Sys_UserDto> result = account.Select(item =>
        // {
        //     item.UpdateTimeStr = item.UpdateTime?.ToString("yyyy/MM/dd HH:mm:ss");
        //     item.ListRole = accountRoles.Where(r => r.Account == item.UserName).Select(r => r.Role).Distinct().ToList();

        //     item.IsActivestr = param.Lang == "zh" ? (!item.IsActive ? "N.啟用" : "Y.停用") : (!item.IsActive ? "N.Disabled" : "Y.Enabled");
        //     item.Role = string.Join("/ ", item.ListRole);
        //     return item;
        // }).ToList();

        // if (!string.IsNullOrWhiteSpace(param.Role) && param.ListRole.Count > 0)
        // {
        //     result = result.Where(item => item.ListRole.Any(role => param.ListRole.Contains(role))).ToList();
        // }

        return users;
    }

    public async Task<Sys_User?> GetById(int id)
    {
        return await _repositoryAccessor.Sys_User.FirstOrDefaultAsync(x => x.Id == id);
    }
}
