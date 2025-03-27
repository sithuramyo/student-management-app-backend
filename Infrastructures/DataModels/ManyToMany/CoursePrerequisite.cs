namespace Infrastructures.DataModels.ManyToMany;

public class CoursePrerequisite : BaseDataModel
{
    public string CourseId { get; set; } = null!;
    public string PrerequisiteId { get; set; } = null!;
}