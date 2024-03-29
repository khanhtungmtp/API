using API.Models;

namespace API.Dtos.UserManager
{
    public partial class Sys_UserDto
    {
        public Sys_User? Sys_User { get; set; }
        public Sys_Role? Sys_Role { get; set; }
    }
}