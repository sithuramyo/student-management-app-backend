namespace Infrastructures.DataModels.Persons;

public class Faculty : BaseDataModel
{
    public string Code { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? Specialization { get; set; }
    public string Status { get; set; } = null!;
    public string? Profile { get; set; }
}