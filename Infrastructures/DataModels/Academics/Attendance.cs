namespace Infrastructures.DataModels.Academics;

public class Attendance : BaseDataModel
{
    public string StudentId { get; set; } = null!;
    public string CourseId { get; set; } = null!;
    public DateOnly Date { get; set; }
    public string Status { get; set; } = null!; // Present, Absent, Late, Excused
    public string? Notes { get; set; }
}