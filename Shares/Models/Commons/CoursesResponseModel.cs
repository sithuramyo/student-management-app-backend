namespace Shares.Models.Commons;

public class CoursesResponseModel
{
    public List<Courses> Courses { get; set; } = [];
}

public class Courses
{
    public string Id { get; set; }
    public string Profile { get; set; }
    public string Code { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}