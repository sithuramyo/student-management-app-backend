using System.ComponentModel.DataAnnotations;
using Shares.Attributes;
using Shares.Enums;
using Shares.Models.Persons.Students;

namespace Shares.Models.Persons.Faculties;

public class CreateFacultyRequestModel
{
    [Required] public FacultyLoginInfoModel LoginInfo { get; set; }
    [Required] public FacultyInfoModel FacultyInfo { get; set; }
}

public class FacultyLoginInfoModel : StudentLoginInfoModel
{
}

public class FacultyInfoModel
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

    public string Specialization { get; set; }

    [Required(ErrorMessage = "Status is required")]
    [EnumDataType(typeof(FacultyStatus), ErrorMessage = "Invalid status")]
    public FacultyStatus Status { get; set; }

    public string? Profile { get; set; }
}

public class UpdateFacultyRequestModel : FacultyInfoModel
{
}