namespace Infrastructures.DataModels.Academics;

public class CourseOffering : BaseDataModel
{
    public string AcademicTermId { get; set; }
    public string CourseId { get; set; }
    public string FacultyId { get; set; }
}