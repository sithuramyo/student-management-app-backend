namespace Infrastructures.DataModels.SystemUsers;

public class SystemUser : BaseDataModel
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string? Profile { get; set; }
}