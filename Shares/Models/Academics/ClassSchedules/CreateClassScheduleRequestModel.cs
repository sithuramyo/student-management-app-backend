using System.ComponentModel.DataAnnotations;
using Shares.Attributes;

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
    [Required(ErrorMessage = "Schedule date is required")]
    [FutureOrTodayOnly(ErrorMessage = "Schedule date must be today or in the future")]
    public DateOnly ScheduleDate { get; set; }
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