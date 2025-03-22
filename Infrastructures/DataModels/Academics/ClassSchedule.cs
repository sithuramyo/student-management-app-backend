namespace Infrastructures.DataModels.Academics;

public class ClassSchedule : BaseDataModel
{
    public string CourseCode { get; set; }
    public string FacultyCode { get; set; }
    public DayOfWeek DayOfWeek { get; set; }     // Monday, Tuesday, etc.
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string Location { get; set; } 
}