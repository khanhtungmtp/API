using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore.Storage;
namespace API._Repositories
{
    public class RepositoryAccessor : IRepositoryAccessor
    {
        private readonly BaseAdminContext _dbContext;
        public RepositoryAccessor(BaseAdminContext dbContext)
        {
            _dbContext = dbContext;
            Sys_User = new Repository<Sys_User, BaseAdminContext>(_dbContext);
            Sys_Role = new Repository<Sys_Role, BaseAdminContext>(_dbContext);
            Sys_User_Role = new Repository<Sys_User_Role, BaseAdminContext>(_dbContext);
            // App_Account_Role = new Repository<App_Account_Role, DBContext>(_dbContext);
            // App_Role_ProgramGroup = new Repository<App_Role_ProgramGroup, DBContext>(_dbContext);
            // App_Role = new Repository<App_Role, DBContext>(_dbContext);
            // System_Directory = new Repository<System_Directory, DBContext>(_dbContext);
            // System_Language = new Repository<System_Language, DBContext>(_dbContext);
            // System_Program_Function_Code = new Repository<System_Program_Function_Code, DBContext>(_dbContext);
            // System_Program_Function = new Repository<System_Program_Function, DBContext>(_dbContext);
            // System_Program_Language = new Repository<System_Program_Language, DBContext>(_dbContext);
            // System_Program = new Repository<System_Program, DBContext>(_dbContext);
        }

        public IRepository<Sys_User> Sys_User { get; set; }

        public IRepository<Sys_Role> Sys_Role { get; set; }

        public IRepository<Sys_User_Role> Sys_User_Role { get; set; }

        // public IRepository<App_Account_Role> App_Account_Role { get; set; }

        // public IRepository<App_Role_ProgramGroup> App_Role_ProgramGroup { get; set; }

        // public IRepository<App_Role> App_Role { get; set; }

        // public IRepository<System_Directory> System_Directory { get; set; }

        // public IRepository<System_Language> System_Language { get; set; }

        // public IRepository<System_Program_Function_Code> System_Program_Function_Code { get; set; }

        // public IRepository<System_Program_Function> System_Program_Function { get; set; }

        // public IRepository<System_Program_Language> System_Program_Language { get; set; }

        // public IRepository<System_Program> System_Program { get; set; }

        public async Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }
    }
}