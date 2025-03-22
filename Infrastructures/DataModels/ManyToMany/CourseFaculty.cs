namespace Infrastructures.DataModels.ManyToMany;

public class CourseFaculty : BaseDataModel
{
    public string CourseCode { get; set; } = null!;
    public string FacultyCode { get; set; } = null!;
}