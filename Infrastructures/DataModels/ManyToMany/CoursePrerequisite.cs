namespace Infrastructures.DataModels.ManyToMany;

public class CoursePrerequisite : BaseDataModel
{
    public string CourseCode { get; set; } = null!;
    public string PrerequisiteId { get; set; } = null!;
}