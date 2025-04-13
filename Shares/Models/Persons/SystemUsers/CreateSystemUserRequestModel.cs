using System.ComponentModel.DataAnnotations;
using Shares.Enums;

namespace Shares.Models.Persons.SystemUsers;

public class CreateSystemUserRequestModel
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$",
        ErrorMessage =
            "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Status is required")]
    [EnumDataType(typeof(SystemUserRole), ErrorMessage = "Invalid role")]
    public SystemUserRole Role { get; set; }
    public string Profile { get; set; }
}

public class UpdateSystemUserRequestModel : CreateSystemUserRequestModel
{
}