namespace Shares.Models.Faculties;

public class FacultyTodayClassScheduleResponseModel
{
    public List<FacultyTodayClassSchedule> FacultyTodayClassSchedule { get; set; } = [];
}

public class FacultyTodayClassSchedule
{
    public string Id { get; set; }
    public string CourseName { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string Location { get; set; }
}