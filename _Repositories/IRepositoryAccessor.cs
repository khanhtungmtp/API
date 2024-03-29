using API.Models;
using Microsoft.EntityFrameworkCore.Storage;
using static API.Configurations.DependencyInjectionConfig;
namespace API._Repositories
{
    [DependencyInjection(ServiceLifetime.Scoped)]
    public interface IRepositoryAccessor
    {
        Task<bool> SaveAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
        IRepository<Sys_User> Sys_User { get; }
        IRepository<Sys_Role> Sys_Role { get; }
        IRepository<Sys_User_Role> Sys_User_Role { get; }
        // IRepository<App_Account_Role> App_Account_Role { get; }
        // IRepository<App_Role_ProgramGroup> App_Role_ProgramGroup { get; }
        // IRepository<App_Role> App_Role { get; }
        // IRepository<System_Directory> System_Directory { get; }
        // IRepository<System_Language> System_Language { get; }
        // IRepository<System_Program_Function_Code> System_Program_Function_Code { get; }
        // IRepository<System_Program_Function> System_Program_Function { get; }
        // IRepository<System_Program_Language> System_Program_Language { get; }
        // IRepository<System_Program> System_Program { get; }
    }
}