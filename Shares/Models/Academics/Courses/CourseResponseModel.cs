using System.Text.Json.Serialization;

namespace Shares.Models.Academics.Courses;

public class CourseResponseModel
{
    public string Id { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string[]? PrerequisiteIds { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? DepartmentName { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string? DepartmentId { get; set; }
    public string? Profile { get; set; }
    public string Code { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal CreditHours { get; set; }
    public string? SemesterOffered { get; set; }
    public int? MaxEnrollment { get; set; }
    public string? SyllabusUrl { get; set; }
    public string? DeliveryMode { get; set; }
}