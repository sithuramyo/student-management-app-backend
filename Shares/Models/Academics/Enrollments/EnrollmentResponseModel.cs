namespace Shares.Models.Academics.Enrollments;

public class EnrollmentResponseModel
{
    public string Id { get; set; }
    public string AcademicTerm { get; set; }
    public int StudentCount { get; set; }
    public int CourseCount { get; set; }
    public int FacultyCount { get; set; }
}