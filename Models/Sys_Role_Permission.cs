using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[PrimaryKey("Id")]
[Table("Sys_Role_Permission")]
public partial class Sys_Role_Permission
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int RoleId { get; set; }
    public int DirectoryId { get; set; }
}
