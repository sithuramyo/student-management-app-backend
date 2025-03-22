namespace Infrastructures.DataModels.Persons;

public class Faculty : BaseDataModel
{
    public string SystemUserId { get; set; } 
    public string Code { get; set; }
    public string PhoneNumber { get; set; }
    public string? Specialization { get; set; }
    public string Status { get; set; }
}