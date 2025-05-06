namespace Shares.Models.Academics.ClassSchedules;

public class ClassScheduleResponseModel
{
    public string Id { get; set; }
    public string CourseTitle { get; set; }
    public string FacultyName { get; set; }
    public DateOnly ScheduleDate { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string Location { get; set; }
}