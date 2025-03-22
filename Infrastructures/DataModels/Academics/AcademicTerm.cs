namespace Infrastructures.DataModels.Academics;

public class AcademicTerm : BaseDataModel
{
    public string? Profile { get; set; }
    public string Name { get; set; }  = null!;           // e.g., Spring 2025
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsCurrentTerm { get; set; }
}