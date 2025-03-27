namespace Infrastructures.DataModels.Academics;

public class Enrollment : BaseDataModel
{
    public string StudentId { get; set; } = null!;
    public string CourseId { get; set; } = null!;
    public string AcademicTermId { get; set; } = null!;
    public DateTime EnrollmentDate { get; set; }
    public string Status { get; set; } = null!;
    public string? GradeReportId { get; set; }
}