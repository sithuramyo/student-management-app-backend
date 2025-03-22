namespace Infrastructures.DataModels.Academics;

public class Course : BaseDataModel
{
    public string? DepartmentId { get; set; }
    public string? Profile { get; set; }
    public string Code { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal CreditHours { get; set; }
    public string? SemesterOffered { get; set; }
    public int? MaxEnrollment { get; set; }
    public string? SyllabusUrl { get; set; }
    public string? DeliveryMode { get; set; }
    public string? Prerequisite { get; set; }
}