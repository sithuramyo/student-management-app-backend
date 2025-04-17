namespace Shares.Models.Commons;

public class AcademicTermsResponseModel
{
    public List<AcademicTerm> AcademicTerms { get; set; } = [];
}

public class AcademicTerm
{
    public string Id { get; set; }
    public string Name { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}