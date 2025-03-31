namespace Shares.Models.Commons;

public class PrerequisiteResponseModel
{
    public List<Prerequisites> Prerequisites { get; set; } = [];
}

public class Prerequisites
{
    public string Id { get; set; }
    public string RequiredCourseCode { get; set; }
    public string RequiredMinimumGrade { get; set; }
    public bool IsMandatory { get; set; }
    public string Notes { get; set; }
}