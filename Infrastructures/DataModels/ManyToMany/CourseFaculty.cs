namespace Infrastructures.DataModels.ManyToMany;

public class CourseFaculty : BaseDataModel
{
    public string CourseId { get; set; } = null!;
    public string FacultyCode { get; set; } = null!;
}