namespace Shares.Models.Academics.AcademicTerms;

public class AcademicTermResponseModel
{
    public string Id { get; set; }
    public string Profile { get; set; }
    public string Name { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}