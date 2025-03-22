using Infrastructures.DataModels.Base;

namespace Infrastructures.DataModels.Persons;

public class Student : BaseDataModel
{
    public string Code { get; set; }
    public string FullName { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Status { get; set; }
    public string? Profile { get; set; }
}