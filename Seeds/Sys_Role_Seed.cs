using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Seeds;

public class Sys_Role_Seed : IEntityTypeConfiguration<Sys_Role>
{
    public void Configure(EntityTypeBuilder<Sys_Role> builder)
    {
        builder.HasData
        (
            new Sys_Role
            {
                Id = 1,
                RoleName = "SuperAdmin",
                RoleDescription = "Role for SuperAdmin",
                UpdateBy = "System",
                UpdateTime = DateTime.Now
            },
            new Sys_Role
            {
                Id = 2,
                RoleName = "Admin",
                RoleDescription = "Role for Admin",
                UpdateBy = "System",
                UpdateTime = DateTime.Now
            },
            new Sys_Role
            {
                Id = 3,
                RoleName = "User",
                RoleDescription = "Role for User",
                UpdateBy = "System",
                UpdateTime = DateTime.Now
            }
        );
    }
}
