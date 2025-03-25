using System.ComponentModel.DataAnnotations;

namespace Shares.Models.Academics.Courses;

public class CreateCourseRequestModel
{
    public string Profile { get; set; }
    public string DepartmentId { get; set; }
    [Required(ErrorMessage = "Course Code is required")]
    public string Code { get; set; }
    [Required(ErrorMessage = "Course Title is required")]
    public string Title { get; set; }
    [Required(ErrorMessage = "Course Description is required")]
    public string Description { get; set; }
    [Required(ErrorMessage = "Credit hours is required")]
    [Range(1, 100, ErrorMessage = "Credit hours must be at least 1")]
    public decimal CreditHours { get; set; }
    public string? SemesterOffered { get; set; }
    [Required(ErrorMessage = "Enrollment is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Max enrollment must be greater than 0")]
    public int MaxEnrollment { get; set; }
    public string? SyllabusUrl { get; set; }
    public string? DeliveryMode { get; set; }
}

public class UpdateCourseRequestModel : CreateCourseRequestModel { }