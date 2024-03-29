using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[PrimaryKey("Id")]
[Table("Sys_Role")]
[Index("RoleName", Name = "rolename_idx", IsUnique = true)]
public partial class Sys_Role
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public required string RoleName { get; set; }

    [StringLength(255)]
    public required string RoleDescription { get; set; }

    [StringLength(20)]
    public required string UpdateBy { get; set; }

    [Required]
    public DateTime CreateTime { get; set; }

    [Required]
    public DateTime UpdateTime { get; set; }
    [ForeignKey("Id")]
    public Sys_User? User { get; set; }
    public ICollection<Sys_User_Role>? UserRoles { get; set; }
}
