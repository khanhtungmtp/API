using API._Repositories;
using API._Services.Interfaces.UserManager;
using API.Dtos.UserManager;
using API.Helpers.Utilities;
using API.Models;
using AutoMapper;
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

        List<Sys_User> usersWithRoles = await _repositoryAccessor.Sys_User
        .FindAll(true)
        .Select(user => new Sys_User
        {
            Id = user.Id,
            UserName = user.UserName,
            PasswordHash = user.PasswordHash,
            PasswordSalt = user.PasswordSalt,
            FullName = user.FullName,
            IsActive = user.IsActive,
            Avatar = user.Avatar,
            Sex = user.Sex,
            Mobile = user.Mobile,
            Email = user.Email,
            LastLoginTime = user.LastLoginTime,
            Education = user.Education,
            DepartmentId = user.DepartmentId,
            UpdateBy = user.UpdateBy,
            CreateTime = user.CreateTime,
            UpdateTime = user.UpdateTime,
            // Lấy danh sách vai trò của người dùng
            Roles = user.UserRoles != null ? user.UserRoles.Select(ur => ur.Role).ToList() : null
        }).ToListAsync();

        return usersWithRoles;
    }

    public async Task<Sys_User?> GetById(int id)
    {
        return await _repositoryAccessor.Sys_User
        .FindAll(true)
        .Where(u => u.Id == id)
        .Select(user => new Sys_User
        {
            Id = user.Id,
            UserName = user.UserName,
            PasswordHash = user.PasswordHash,
            PasswordSalt = user.PasswordSalt,
            FullName = user.FullName,
            IsActive = user.IsActive,
            Avatar = user.Avatar,
            Sex = user.Sex,
            Mobile = user.Mobile,
            Email = user.Email,
            LastLoginTime = user.LastLoginTime,
            Education = user.Education,
            DepartmentId = user.DepartmentId,
            UpdateBy = user.UpdateBy,
            CreateTime = user.CreateTime,
            UpdateTime = user.UpdateTime,
            // Lấy danh sách vai trò của người dùng
            Roles = user.UserRoles != null ? user.UserRoles.Select(ur => ur.Role).ToList() : null
        }).FirstOrDefaultAsync();

    }

}
