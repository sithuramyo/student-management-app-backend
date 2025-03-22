namespace Infrastructures.DataModels.Academics;

public class Prerequisite : BaseDataModel
{
    public string RequiredCourseCode { get; set; } = null!;
    public string? MinimumGradeRequired { get; set; } // Optional: e.g., B, C+, Pass
    public bool IsMandatory { get; set; } = true;     // Optional
    public string? Notes { get; set; }
}