namespace Infrastructures.DataModels.Academics;

public class Attendance : BaseDataModel
{
    public string StudentCode { get; set; } = null!;
    public string CourseCode { get; set; } = null!;
    public DateOnly Date { get; set; }
    public string Status { get; set; } = null!; // Present, Absent, Late, Excused
    public string? Notes { get; set; }
}