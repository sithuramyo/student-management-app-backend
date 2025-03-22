namespace Infrastructures.DataModels.Academics;

public class Department : BaseDataModel
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? OfficeLocation { get; set; }
}