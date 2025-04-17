namespace Infrastructures.DataModels.Academics;

public class Enrollment : BaseDataModel
{
    public string StudentId { get; set; } = null!;
    public string CourseOfferingId { get; set; } = null!;
    public DateTime EnrollmentDate { get; set; }
    public string? GradeReportId { get; set; }
}