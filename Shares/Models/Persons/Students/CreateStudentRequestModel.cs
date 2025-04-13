using System.ComponentModel.DataAnnotations;
using Shares.Attributes;
using Shares.Enums;

namespace Shares.Models.Persons.Students;

public class CreateStudentRequestModel
{
    [Required]
    public StudentLoginInfoModel LoginInfo { get; set; }
    [Required]
    public StudentInfoModel StudentInfo { get; set; }
    [Required]
    public GuardianInfoModel GuardianInfo { get; set; }
}

public class StudentLoginInfoModel
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).+$",
        ErrorMessage =
            "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character")]
    public string Password { get; set; }
}

public class StudentInfoModel
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Birth date is required")]
    [PastDateOnly(ErrorMessage = "Birth date cannot be in the future")]
    public DateOnly BirthDate { get; set; }

    [Required(ErrorMessage = "Gender is required")]
    [EnumDataType(typeof(Gender), ErrorMessage = "Invalid gender")]
    public Gender Gender { get; set; }

    [Required(ErrorMessage = "Phone number is required")]
    [RegularExpression(@"^(\+?95|09)\d{7,9}$", ErrorMessage = "Enter a valid Myanmar phone number")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Status is required")]
    [EnumDataType(typeof(StudentStatus), ErrorMessage = "Invalid status")]
    public StudentStatus Status { get; set; }

    public string? Profile { get; set; }
}

public class GuardianInfoModel
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Relationship is required")]
    public string Relationship { get; set; }

    [Required(ErrorMessage = "Contact number is required")]
    [RegularExpression(@"^(\+?95|09)\d{7,9}$", ErrorMessage = "Enter a valid Myanmar phone number")]
    public string ContactNumber { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string? Email { get; set; }

    public string? Address { get; set; }
}

public class UpdateStudentRequestModel : StudentInfoModel
{
}