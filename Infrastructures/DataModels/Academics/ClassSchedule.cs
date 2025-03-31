namespace Infrastructures.DataModels.Academics;

public class ClassSchedule : BaseDataModel
{
    public string CourseId { get; set; } = null!;
    public string FacultyId { get; set; } = null!;
    public DayOfWeek DayOfWeek { get; set; } // Monday, Tuesday, etc.
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string Location { get; set; } = null!;
}