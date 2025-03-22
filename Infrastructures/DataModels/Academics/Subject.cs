namespace Infrastructures.DataModels.Academics;

public class Subject : BaseDataModel
{
    public string CourseCode { get; set; } = null!;
    public string? Profile { get; set; }
    public string Code { get; set; }  = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Level { get; set; }
}