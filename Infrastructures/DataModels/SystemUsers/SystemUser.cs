namespace Infrastructures.DataModels.SystemUsers;

public class SystemUser : BaseDataModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string? Profile { get; set; }
}