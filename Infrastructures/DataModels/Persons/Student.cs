namespace Infrastructures.DataModels.Persons;

public class Student : BaseDataModel
{
    public string SystemUserId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public string Gender { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string? Profile { get; set; }
}