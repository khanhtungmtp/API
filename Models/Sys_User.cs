using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

[Table("Sys_User")]
[Index("UserName", Name = "name_idx", IsUnique = true)]
public partial class Sys_User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    [Unicode(false)]
    public required string UserName { get; set; }
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
    [StringLength(20)]
    public required string FullName { get; set; }
    public bool IsActive { get; set; }
    public string? Avatar { get; set; }
    public int Sex { get; set; }

    [StringLength(11)]
    [Unicode(false)]
    public string? Mobile { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Email { get; set; }

    public DateTime? LastLoginTime { get; set; }

    public byte? Education { get; set; }

    public int? DepartmentId { get; set; }

    [StringLength(20)]
    public required string UpdateBy { get; set; }

    [Required]
    public DateTime CreateTime { get; set; }
    [Required]
    public DateTime UpdateTime { get; set; }
    // Định nghĩa mối quan hệ ngược từ Sys_User_Role
    public virtual ICollection<Sys_User_Role>? UserRoles { get; set; }
    public virtual ICollection<Sys_Role>? Roles { get; set; }
}
