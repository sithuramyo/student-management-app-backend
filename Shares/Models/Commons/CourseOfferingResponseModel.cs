using Shares.Models.Academics.CourseOfferings;

namespace Shares.Models.Commons;

public class CourseOfferingsResponseModel
{
    public List<CourseOfferings> CourseOfferings { get; set; } = [];
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}

public class CourseOfferings
{
    public string Id { get; set; }
    public string CourseId { get; set; }
    public string FacultyId { get; set; }
}