using System.ComponentModel.DataAnnotations;

namespace Shares.Models.Academics.Departments;

public class CreateDepartmentRequestModel
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? PhoneNumber { get; set; }
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string? Email { get; set; }
    public string? OfficeLocation { get; set; }
}

public class UpdateDepartmentRequestModel : CreateDepartmentRequestModel { }