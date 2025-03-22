namespace Infrastructures.DataModels.Persons;

public class Faculty : BaseDataModel
{
    public string Code { get; set; } 
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string? Specialization { get; set; }
    public string Status { get; set; }
    public string? Profile { get; set; }
}