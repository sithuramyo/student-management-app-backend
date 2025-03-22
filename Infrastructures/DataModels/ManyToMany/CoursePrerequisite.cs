namespace Infrastructures.DataModels.ManyToMany;

public class CoursePrerequisite : BaseDataModel
{
    public string CourseCode { get; set; }
    public string PrerequisiteId { get; set; }
}