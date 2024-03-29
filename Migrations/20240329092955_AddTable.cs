using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AddTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sys_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Mobile = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    LastLoginTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Education = table.Column<byte>(type: "tinyint", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoleDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UpdateBy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sys_Role_Sys_User_Id",
                        column: x => x.Id,
                        principalTable: "Sys_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sys_User_Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_User_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sys_User_Role_Sys_Role_Id",
                        column: x => x.Id,
                        principalTable: "Sys_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sys_User_Role_Sys_User_Id",
                        column: x => x.Id,
                        principalTable: "Sys_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sys_User",
                columns: new[] { "Id", "Avatar", "CreateTime", "DepartmentId", "Education", "Email", "FullName", "IsActive", "LastLoginTime", "Mobile", "PasswordHash", "PasswordSalt", "Sex", "UpdateBy", "UpdateTime", "UserName" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2024, 3, 29, 16, 29, 54, 985, DateTimeKind.Local).AddTicks(4624), 15, (byte)3, "superadmin@gmail.com", "Nguyễn Khanh Tùng", true, new DateTime(2024, 3, 28, 22, 1, 2, 0, DateTimeKind.Unspecified), "0338716085", new byte[] { 238, 186, 156, 111, 96, 221, 124, 224, 77, 109, 56, 117, 239, 246, 150, 102, 14, 205, 48, 67, 111, 253, 98, 101, 112, 133, 212, 219, 7, 41, 219, 74, 156, 244, 82, 149, 185, 118, 187, 174, 112, 81, 50, 149, 248, 58, 91, 192, 159, 140, 24, 167, 167, 68, 30, 211, 193, 244, 121, 88, 225, 156, 183, 94 }, new byte[] { 242, 112, 199, 13, 248, 151, 103, 245, 119, 53, 85, 164, 145, 110, 211, 75, 204, 250, 32, 208, 41, 190, 161, 104, 220, 174, 254, 73, 21, 201, 193, 35, 134, 239, 168, 156, 67, 55, 159, 194, 178, 232, 8, 66, 131, 244, 61, 166, 162, 218, 28, 1, 213, 254, 96, 50, 83, 60, 202, 88, 132, 186, 137, 228, 158, 239, 213, 120, 21, 175, 178, 92, 23, 255, 61, 4, 1, 156, 176, 16, 21, 207, 15, 23, 125, 197, 241, 230, 52, 250, 71, 176, 115, 65, 26, 89, 61, 170, 253, 171, 72, 109, 87, 56, 6, 224, 221, 41, 68, 233, 102, 238, 111, 218, 74, 39, 110, 91, 43, 147, 57, 47, 24, 250, 17, 33, 214, 178 }, 1, "System", new DateTime(2024, 3, 29, 16, 29, 54, 985, DateTimeKind.Local).AddTicks(4635), "superadmin" },
                    { 2, "", new DateTime(2024, 3, 29, 16, 29, 54, 985, DateTimeKind.Local).AddTicks(4644), 29, (byte)3, "superadmin@gmail.com", "Nguyễn Khanh Tùng", true, new DateTime(2024, 3, 28, 22, 1, 2, 0, DateTimeKind.Unspecified), "0338716085", new byte[] { 238, 186, 156, 111, 96, 221, 124, 224, 77, 109, 56, 117, 239, 246, 150, 102, 14, 205, 48, 67, 111, 253, 98, 101, 112, 133, 212, 219, 7, 41, 219, 74, 156, 244, 82, 149, 185, 118, 187, 174, 112, 81, 50, 149, 248, 58, 91, 192, 159, 140, 24, 167, 167, 68, 30, 211, 193, 244, 121, 88, 225, 156, 183, 94 }, new byte[] { 242, 112, 199, 13, 248, 151, 103, 245, 119, 53, 85, 164, 145, 110, 211, 75, 204, 250, 32, 208, 41, 190, 161, 104, 220, 174, 254, 73, 21, 201, 193, 35, 134, 239, 168, 156, 67, 55, 159, 194, 178, 232, 8, 66, 131, 244, 61, 166, 162, 218, 28, 1, 213, 254, 96, 50, 83, 60, 202, 88, 132, 186, 137, 228, 158, 239, 213, 120, 21, 175, 178, 92, 23, 255, 61, 4, 1, 156, 176, 16, 21, 207, 15, 23, 125, 197, 241, 230, 52, 250, 71, 176, 115, 65, 26, 89, 61, 170, 253, 171, 72, 109, 87, 56, 6, 224, 221, 41, 68, 233, 102, 238, 111, 218, 74, 39, 110, 91, 43, 147, 57, 47, 24, 250, 17, 33, 214, 178 }, 1, "System", new DateTime(2024, 3, 29, 16, 29, 54, 985, DateTimeKind.Local).AddTicks(4645), "admin" },
                    { 3, "", new DateTime(2024, 3, 29, 16, 29, 54, 985, DateTimeKind.Local).AddTicks(4651), 17, (byte)3, "superadmin@gmail.com", "Nguyễn Thanh Trung", true, new DateTime(2024, 3, 28, 22, 1, 2, 0, DateTimeKind.Unspecified), "0338716085", new byte[] { 238, 186, 156, 111, 96, 221, 124, 224, 77, 109, 56, 117, 239, 246, 150, 102, 14, 205, 48, 67, 111, 253, 98, 101, 112, 133, 212, 219, 7, 41, 219, 74, 156, 244, 82, 149, 185, 118, 187, 174, 112, 81, 50, 149, 248, 58, 91, 192, 159, 140, 24, 167, 167, 68, 30, 211, 193, 244, 121, 88, 225, 156, 183, 94 }, new byte[] { 242, 112, 199, 13, 248, 151, 103, 245, 119, 53, 85, 164, 145, 110, 211, 75, 204, 250, 32, 208, 41, 190, 161, 104, 220, 174, 254, 73, 21, 201, 193, 35, 134, 239, 168, 156, 67, 55, 159, 194, 178, 232, 8, 66, 131, 244, 61, 166, 162, 218, 28, 1, 213, 254, 96, 50, 83, 60, 202, 88, 132, 186, 137, 228, 158, 239, 213, 120, 21, 175, 178, 92, 23, 255, 61, 4, 1, 156, 176, 16, 21, 207, 15, 23, 125, 197, 241, 230, 52, 250, 71, 176, 115, 65, 26, 89, 61, 170, 253, 171, 72, 109, 87, 56, 6, 224, 221, 41, 68, 233, 102, 238, 111, 218, 74, 39, 110, 91, 43, 147, 57, 47, 24, 250, 17, 33, 214, 178 }, 0, "System", new DateTime(2024, 3, 29, 16, 29, 54, 985, DateTimeKind.Local).AddTicks(4652), "user" }
                });

            migrationBuilder.InsertData(
                table: "Sys_User_Role",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 4, 1, 4 },
                    { 5, 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "Sys_Role",
                columns: new[] { "Id", "CreateTime", "RoleDescription", "RoleName", "UpdateBy", "UpdateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Role for SuperAdmin", "SuperAdmin", "System", new DateTime(2024, 3, 29, 16, 29, 54, 985, DateTimeKind.Local).AddTicks(4909) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Role for Admin", "Admin", "System", new DateTime(2024, 3, 29, 16, 29, 54, 985, DateTimeKind.Local).AddTicks(4911) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Role for User", "User", "System", new DateTime(2024, 3, 29, 16, 29, 54, 985, DateTimeKind.Local).AddTicks(4912) }
                });

            migrationBuilder.InsertData(
                table: "Sys_User_Role",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "rolename_idx",
                table: "Sys_Role",
                column: "RoleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "name_idx",
                table: "Sys_User",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sys_User_Role");

            migrationBuilder.DropTable(
                name: "Sys_Role");

            migrationBuilder.DropTable(
                name: "Sys_User");
        }
    }
}
