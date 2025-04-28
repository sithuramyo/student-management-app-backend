using System.ComponentModel.DataAnnotations;

namespace Shares.Models.Academics.ClassSchedules;

public class CreateClassScheduleRequestModel
{
    public List<CourseScheduleInfoModel> CourseSchedules { get; set; }
}


public class CourseScheduleInfoModel
{
    [Required]
    public string CourseOfferingId { get; set; }
    [Required]
    public string CourseTitle { get; set; }
    [Required]
    public string FacultyName { get; set; }
    [Required]
    public DayOfWeek DayOfWeek { get; set; }
    [Required]
    public TimeOnly StartTime { get; set; }
    [Required]
    public TimeOnly EndTime { get; set; }
    [Required]
    public string Location { get; set; }
}


public class UpdateClassScheduleRequestModel : CreateClassScheduleRequestModel { }