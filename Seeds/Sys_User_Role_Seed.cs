
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace API.Seeds;

public class Sys_User_Role_Seed : IEntityTypeConfiguration<Sys_User_Role>
{
    public void Configure(EntityTypeBuilder<Sys_User_Role> builder)
    {
        builder.HasData
        (
            new Sys_User_Role
            {
                Id = 1,
                UserId = 1,
                RoleId = 1
            },
            new Sys_User_Role
            {
                Id = 2,
                UserId = 2,
                RoleId = 2
            },
            new Sys_User_Role
            {
                Id = 3,
                UserId = 3,
                RoleId = 2
            },
            new Sys_User_Role
            {
                Id = 4,
                UserId = 4,
                RoleId = 1
            },
            new Sys_User_Role
            {
                Id = 5,
                UserId = 5,
                RoleId = 1
            }
        );
    }
}
