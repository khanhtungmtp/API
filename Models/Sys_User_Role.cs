using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[PrimaryKey("Id")]
[Table("Sys_User_Role")]
public partial class Sys_User_Role
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int UserId { get; set; }
    public int RoleId { get; set; }

    [ForeignKey("Id")]
    public Sys_User? User { get; set; }

    [ForeignKey("Id")]
    public Sys_Role? Role { get; set; }
}
