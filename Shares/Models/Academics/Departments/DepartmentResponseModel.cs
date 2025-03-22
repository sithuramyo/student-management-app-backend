namespace Shares.Models.Academics.Departments;

public class DepartmentResponseModel
{
    public string Id { get; set; }
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? OfficeLocation { get; set; }
}