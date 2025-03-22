namespace Infrastructures.DataModels.Academics;

public class Attendance : BaseDataModel
{
    public string StudentCode { get; set; }
    public string CourseCode { get; set; }
    public DateOnly Date { get; set; }
    public string Status { get; set; }           // Present, Absent, Late, Excused
    public string? Notes { get; set; }
}