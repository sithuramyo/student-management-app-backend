namespace Infrastructures.DataModels.Persons;

public class Faculty : BaseDataModel
{
    public string SystemUserId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string? Specialization { get; set; }
    public string Status { get; set; }
    public string? Profile { get; set; }
}