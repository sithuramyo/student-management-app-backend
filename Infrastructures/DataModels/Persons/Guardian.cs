using Infrastructures.DataModels.Base;

namespace Infrastructures.DataModels.Persons;

public class Guardian : BaseDataModel
{
    public string StudentCode { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Relationship { get; set; } = null!;
    public string ContactNumber { get; set; } = null!;
    public string? Email { get; set; }
    public string? Address { get; set; }
}