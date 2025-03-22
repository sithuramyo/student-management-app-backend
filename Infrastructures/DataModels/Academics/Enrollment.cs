namespace Infrastructures.DataModels.Academics;

public class Enrollment : BaseDataModel
{
    public string StudentCode { get; set; }
    public string CourseCode { get; set; }
    public string AcademicTermId { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string Status { get; set; }   
    public string? GradeReportId { get; set; }
}