namespace Infrastructures.DataModels.Academics;

public class ClassSchedule : BaseDataModel
{
    public string CourseOfferingId { get; set; } = null!;
    public DayOfWeek DayOfWeek { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string Location { get; set; } = null!;
}