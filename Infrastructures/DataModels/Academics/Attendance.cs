namespace Infrastructures.DataModels.Academics;

public class Attendance : BaseDataModel
{
    public string StudentId { get; set; } = null!;
    public string ClassScheduleId { get; set; } = null!;
    public DateOnly Date { get; set; }
    public string Status { get; set; } = null!;
    public string? Notes { get; set; }
}