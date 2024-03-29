using API.Models;
using API.Seeds;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class BaseAdminContext(DbContextOptions<BaseAdminContext> options) : DbContext(options)
{
    public virtual DbSet<Sys_User>? Sys_User { get; set; }
    public virtual DbSet<Sys_Role>? Sys_Role { get; set; }
    public virtual DbSet<Sys_User_Role>? Sys_User_Role { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Setting a primary key in models
        builder.Entity<Sys_User>().HasKey(x => x.Id);
        builder.Entity<Sys_Role>().HasKey(x => x.Id);
        builder.Entity<Sys_User_Role>().HasKey(x => x.Id);
        builder.Entity<Sys_User_Role>()
       .HasOne(ur => ur.User)
       .WithMany(u => u.UserRoles)
       .HasForeignKey(ur => ur.UserId)
       .OnDelete(DeleteBehavior.Restrict); // Hoặc DeleteBehavior.NoAction

        builder.Entity<Sys_User_Role>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId)
            .OnDelete(DeleteBehavior.Restrict); // Hoặc DeleteBehavior.NoAction
        // seed data default
        builder.ApplyConfiguration(new Sys_User_Seed());
        builder.ApplyConfiguration(new Sys_Role_Seed());
        builder.ApplyConfiguration(new Sys_User_Role_Seed());
        // builder.ApplyConfiguration(new AppAccountRoleSeed());
        // builder.ApplyConfiguration(new AppRoleProgramGroupSeed());
        // builder.ApplyConfiguration(new SystemDirectorySeed());
        // builder.ApplyConfiguration(new SystemLanguageSeed());
        // builder.ApplyConfiguration(new SystemProgramFunctionCodeSeed());
        // builder.ApplyConfiguration(new SystemProgramFunctionSeed());
        // builder.ApplyConfiguration(new SystemProgramLanguageSeed());
        // builder.ApplyConfiguration(new SystemProgramSeed());
    }
}
