namespace API.Dtos.UserManager;

public class UserManagerSearchParam
{
    public string? UserName { get; set; }
    public string? FullName { get; set; }
    public bool? IsActive { get; set; }
    public string? Mobile { get; set; }
    public string? Email { get; set; }

}
