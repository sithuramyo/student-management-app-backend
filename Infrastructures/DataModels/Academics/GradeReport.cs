namespace Infrastructures.DataModels.Academics;

public class GradeReport : BaseDataModel
{
    public string StudentCode { get; set; }
    public string AcademicTermId { get; set; }
    public decimal GPA { get; set; }
    public string Remarks { get; set; }
}