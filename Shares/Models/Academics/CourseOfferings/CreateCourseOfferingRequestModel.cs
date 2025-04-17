using System.ComponentModel.DataAnnotations;

namespace Shares.Models.Academics.CourseOfferings;

public class CreateCourseOfferingRequestModel
{
    [Required(ErrorMessage = "Academic Term is required")]
    public string AcademicTermId { get; set; }
    [Required(ErrorMessage = "Course and Faculty information is required")]
    public List<CourseFacultyInfo> CourseFacultyInfo { get; set; }
}

public class CourseFacultyInfo
{
    [Required(ErrorMessage = "Course is required")]
    public string CourseId { get; set; }

    [Required(ErrorMessage = "Faculty is required")]
    public string FacultyId { get; set; }
}


public class UpdateCourseOfferingRequestModel : CreateCourseOfferingRequestModel { }