namespace Infrastructures.DataModels.Academics;

public class Enrollment : BaseDataModel
{
    public string StudentCode { get; set; } = null!;
    public string CourseCode { get; set; } = null!;
    public string AcademicTermId { get; set; } = null!;
    public DateTime EnrollmentDate { get; set; }
    public string Status { get; set; } = null!;
    public string? GradeReportId { get; set; }
}