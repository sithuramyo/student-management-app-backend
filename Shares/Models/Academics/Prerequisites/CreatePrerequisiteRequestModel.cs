using System.ComponentModel.DataAnnotations;

namespace Shares.Models.Academics.Prerequisites;

public class CreatePrerequisiteRequestModel
{
    [Required(ErrorMessage = "Course Code is required")]
    public string RequiredCourseCode { get; set; }
    public string RequiredMinimumGrade { get; set; }
    public bool IsMandatory { get; set; }
    public string Notes { get; set; }
}

public class UpdatePrerequisiteRequestModel : CreatePrerequisiteRequestModel { }