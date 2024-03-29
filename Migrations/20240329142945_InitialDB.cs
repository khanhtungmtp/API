using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_User_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sys_User_Role_Sys_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Sys_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sys_User_Role_Sys_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Sys_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Sys_User",
                columns: new[] { "Id", "Avatar", "CreateTime", "DepartmentId", "Education", "Email", "FullName", "IsActive", "LastLoginTime", "Mobile", "PasswordHash", "PasswordSalt", "Sex", "UpdateBy", "UpdateTime", "UserName" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2024, 3, 29, 21, 29, 44, 125, DateTimeKind.Local).AddTicks(8772), 15, (byte)3, "superadmin@gmail.com", "Nguyễn Khanh Tùng", true, new DateTime(2024, 3, 28, 22, 1, 2, 0, DateTimeKind.Unspecified), "0338716085", new byte[] { 172, 84, 0, 53, 65, 191, 231, 109, 13, 172, 251, 106, 30, 248, 76, 197, 222, 218, 245, 120, 33, 214, 75, 10, 139, 13, 179, 37, 112, 13, 0, 120, 68, 123, 152, 131, 186, 134, 171, 142, 108, 84, 100, 111, 137, 42, 216, 133, 11, 156, 48, 92, 97, 188, 0, 29, 51, 25, 12, 229, 208, 202, 195, 177 }, new byte[] { 103, 156, 76, 20, 132, 58, 219, 231, 124, 87, 125, 41, 36, 249, 117, 74, 84, 105, 216, 192, 203, 198, 116, 19, 28, 121, 178, 239, 33, 193, 108, 34, 173, 94, 122, 221, 92, 134, 2, 134, 12, 103, 158, 251, 154, 27, 153, 71, 70, 164, 177, 177, 110, 209, 254, 13, 111, 105, 217, 143, 11, 44, 233, 248, 214, 58, 203, 59, 13, 145, 95, 42, 181, 132, 97, 134, 232, 33, 54, 146, 245, 77, 80, 89, 208, 175, 207, 96, 236, 205, 169, 121, 159, 195, 118, 34, 127, 5, 119, 230, 250, 171, 177, 172, 148, 212, 232, 73, 200, 104, 171, 156, 136, 122, 173, 92, 53, 11, 7, 141, 189, 225, 152, 112, 56, 97, 124, 118 }, 1, "System", new DateTime(2024, 3, 29, 21, 29, 44, 125, DateTimeKind.Local).AddTicks(8784), "superadmin" },
                    { 2, "", new DateTime(2024, 3, 29, 21, 29, 44, 125, DateTimeKind.Local).AddTicks(8806), 29, (byte)3, "superadmin@gmail.com", "Nguyễn Khanh Tùng", true, new DateTime(2024, 3, 28, 22, 1, 2, 0, DateTimeKind.Unspecified), "0338716085", new byte[] { 172, 84, 0, 53, 65, 191, 231, 109, 13, 172, 251, 106, 30, 248, 76, 197, 222, 218, 245, 120, 33, 214, 75, 10, 139, 13, 179, 37, 112, 13, 0, 120, 68, 123, 152, 131, 186, 134, 171, 142, 108, 84, 100, 111, 137, 42, 216, 133, 11, 156, 48, 92, 97, 188, 0, 29, 51, 25, 12, 229, 208, 202, 195, 177 }, new byte[] { 103, 156, 76, 20, 132, 58, 219, 231, 124, 87, 125, 41, 36, 249, 117, 74, 84, 105, 216, 192, 203, 198, 116, 19, 28, 121, 178, 239, 33, 193, 108, 34, 173, 94, 122, 221, 92, 134, 2, 134, 12, 103, 158, 251, 154, 27, 153, 71, 70, 164, 177, 177, 110, 209, 254, 13, 111, 105, 217, 143, 11, 44, 233, 248, 214, 58, 203, 59, 13, 145, 95, 42, 181, 132, 97, 134, 232, 33, 54, 146, 245, 77, 80, 89, 208, 175, 207, 96, 236, 205, 169, 121, 159, 195, 118, 34, 127, 5, 119, 230, 250, 171, 177, 172, 148, 212, 232, 73, 200, 104, 171, 156, 136, 122, 173, 92, 53, 11, 7, 141, 189, 225, 152, 112, 56, 97, 124, 118 }, 1, "System", new DateTime(2024, 3, 29, 21, 29, 44, 125, DateTimeKind.Local).AddTicks(8808), "admin" },
                    { 3, "", new DateTime(2024, 3, 29, 21, 29, 44, 125, DateTimeKind.Local).AddTicks(8824), 17, (byte)3, "superadmin@gmail.com", "Nguyễn Thanh Trung", true, new DateTime(2024, 3, 28, 22, 1, 2, 0, DateTimeKind.Unspecified), "0338716085", new byte[] { 172, 84, 0, 53, 65, 191, 231, 109, 13, 172, 251, 106, 30, 248, 76, 197, 222, 218, 245, 120, 33, 214, 75, 10, 139, 13, 179, 37, 112, 13, 0, 120, 68, 123, 152, 131, 186, 134, 171, 142, 108, 84, 100, 111, 137, 42, 216, 133, 11, 156, 48, 92, 97, 188, 0, 29, 51, 25, 12, 229, 208, 202, 195, 177 }, new byte[] { 103, 156, 76, 20, 132, 58, 219, 231, 124, 87, 125, 41, 36, 249, 117, 74, 84, 105, 216, 192, 203, 198, 116, 19, 28, 121, 178, 239, 33, 193, 108, 34, 173, 94, 122, 221, 92, 134, 2, 134, 12, 103, 158, 251, 154, 27, 153, 71, 70, 164, 177, 177, 110, 209, 254, 13, 111, 105, 217, 143, 11, 44, 233, 248, 214, 58, 203, 59, 13, 145, 95, 42, 181, 132, 97, 134, 232, 33, 54, 146, 245, 77, 80, 89, 208, 175, 207, 96, 236, 205, 169, 121, 159, 195, 118, 34, 127, 5, 119, 230, 250, 171, 177, 172, 148, 212, 232, 73, 200, 104, 171, 156, 136, 122, 173, 92, 53, 11, 7, 141, 189, 225, 152, 112, 56, 97, 124, 118 }, 0, "System", new DateTime(2024, 3, 29, 21, 29, 44, 125, DateTimeKind.Local).AddTicks(8825), "user" }
                });

            migrationBuilder.InsertData(
                table: "Sys_Role",
                columns: new[] { "Id", "CreateTime", "RoleDescription", "RoleName", "UpdateBy", "UpdateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Role for SuperAdmin", "SuperAdmin", "System", new DateTime(2024, 3, 29, 21, 29, 44, 125, DateTimeKind.Local).AddTicks(9866) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Role for Admin", "Admin", "System", new DateTime(2024, 3, 29, 21, 29, 44, 125, DateTimeKind.Local).AddTicks(9874) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Role for User", "User", "System", new DateTime(2024, 3, 29, 21, 29, 44, 125, DateTimeKind.Local).AddTicks(9893) }
                });

            migrationBuilder.InsertData(
                table: "Sys_User_Role",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 2, 2 },
                    { 5, 3, 3 }
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

            migrationBuilder.CreateIndex(
                name: "IX_Sys_User_Role_RoleId",
                table: "Sys_User_Role",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_User_Role_UserId",
                table: "Sys_User_Role",
                column: "UserId");
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
