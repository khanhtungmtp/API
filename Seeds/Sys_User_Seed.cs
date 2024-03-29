
using API.Helpers.Utilities;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace API.Seeds;

public class Sys_User_Seed : IEntityTypeConfiguration<Sys_User>
{
    readonly string password = "12345678";
    public void Configure(EntityTypeBuilder<Sys_User> builder)
    {
        AuthUtilities.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

        builder.HasData
        (
            new Sys_User
            {
                Id = 1,
                UserName = "superadmin",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsActive = true,
                FullName = "Nguyễn Khanh Tùng",
                Avatar = "",
                Sex = 1, // 0 nu, 1 nam,
                Mobile = "0338716085",
                Email = "superadmin@gmail.com",
                LastLoginTime = DateTime.Parse("2024-03-28 22:01:02"),
                Education = 3, // 1 thcs, 2 thpt, 3 DH, 4 sau DH, 5 thac sy, 6 tien sy
                DepartmentId = 15,
                UpdateBy = "System",
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            },
            new Sys_User
            {
                Id = 2,
                UserName = "admin",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsActive = true,
                FullName = "Nguyễn Khanh Tùng",
                Avatar = "",
                Sex = 1, // 0 nu, 1 nam,
                Mobile = "0338716085",
                Email = "superadmin@gmail.com",
                LastLoginTime = DateTime.Parse("2024-03-28 22:01:02"),
                Education = 3, // 1 thcs, 2 thpt, 3 DH, 4 sau DH, 5 thac sy, 6 tien sy
                DepartmentId = 29,
                UpdateBy = "System",
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            },
            new Sys_User
            {
                Id = 3,
                UserName = "user",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsActive = true,
                FullName = "Nguyễn Thanh Trung",
                Avatar = "",
                Sex = 0, // 0 nu, 1 nam,
                Mobile = "0338716085",
                Email = "superadmin@gmail.com",
                LastLoginTime = DateTime.Parse("2024-03-28 22:01:02"),
                Education = 3, // 1 thcs, 2 thpt, 3 DH, 4 sau DH, 5 thac sy, 6 tien sy
                DepartmentId = 17,
                UpdateBy = "System",
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now
            }
        );
    }
}
