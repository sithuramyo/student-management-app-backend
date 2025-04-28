namespace Infrastructures.DataModels.Academics;

public class ClassSchedule : BaseDataModel
{
    public string CourseOfferingId { get; set; }
    public string CourseTitle { get; set; }
    public string FacultyName { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string Location { get; set; } = null!;
}