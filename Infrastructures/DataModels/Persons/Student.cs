using Infrastructures.DataModels.Base;

namespace Infrastructures.DataModels.Persons;

public class Student : BaseDataModel
{
    public string Code { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public string Gender { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string? Profile { get; set; }
}