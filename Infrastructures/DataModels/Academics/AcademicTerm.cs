namespace Infrastructures.DataModels.Academics;

public class AcademicTerm : BaseDataModel
{
    public string? Profile { get; set; }
    public string Name { get; set; } = null!;
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}