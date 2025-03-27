namespace Infrastructures.DataModels.Academics;

public class GradeReport : BaseDataModel
{
    public string StudentId { get; set; } = null!;
    public string AcademicTermId { get; set; } = null!;
    public decimal GPA { get; set; }
    public string Remarks { get; set; } = null!;
}