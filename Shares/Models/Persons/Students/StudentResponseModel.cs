namespace Shares.Models.Persons.Students;

public class StudentResponseModel
{
    public string Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Profile { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Gender { get; set; }
    public string Status { get; set; }
}