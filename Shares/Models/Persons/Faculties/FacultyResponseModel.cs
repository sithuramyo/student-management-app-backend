namespace Shares.Models.Persons.Faculties;

public class FacultyResponseModel
{
    public string Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Gender { get; set; }
    public string Profile { get; set; }
    public string PhoneNumber { get; set; }
    public string? Specialization { get; set; }
    public string Status { get; set; }
}