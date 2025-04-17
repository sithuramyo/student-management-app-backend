namespace Shares.Models.Academics.CourseOfferings;

public class CourseOfferingResponseModel
{
    public string AcademicTermId { get; set; }
    public string AcademicTerm { get; set; }
    public List<CourseFacultyInfoResponseModel> CourseFacultyInfos { get; set; } = [];
}

public class CourseFacultyInfoResponseModel
{
    public string CourseId { get; set; }
    public string CourseName { get; set; }
    public string FacultyId { get; set; }
    public string FacultyName { get; set; }
}