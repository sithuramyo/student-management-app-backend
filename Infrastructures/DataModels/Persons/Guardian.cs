using Infrastructures.DataModels.Base;

namespace Infrastructures.DataModels.Persons;

public class Guardian : BaseDataModel
{
    public string StudentCode { get; set; }
    public string FullName { get; set; }
    public string Relationship { get; set; }
    public string ContactNumber { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
}