namespace Shares.Models.Academics.Prerequisites;

public class PrerequisiteResponseModel
{
    public string Id { get; set; }
    public string RequiredCourseCode { get; set; }
    public string RequiredMinimumGrade { get; set; }
    public bool IsMandatory { get; set; }
    public string Notes { get; set; }
}