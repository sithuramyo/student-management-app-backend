namespace Shares.Models.Faculties;

public class FacultyClassScheduleResponseModel
{
    public List<FacultyClassSchedule> FacultyClassSchedules { get; set; } = [];
}

public class FacultyClassSchedule
{
    public string Id { get; set; }
    public string Term { get; set; }
    public string CourseTitle { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public DateOnly ScheduleDate { get; set; }
}