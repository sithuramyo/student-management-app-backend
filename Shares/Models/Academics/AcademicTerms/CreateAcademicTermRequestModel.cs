using System.ComponentModel.DataAnnotations;
using Shares.Attributes;

namespace Shares.Models.Academics.AcademicTerms;

public class CreateAcademicTermRequestModel
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    public string? Profile { get; set; }
    [Required(ErrorMessage = "Start date is required")]
    [FutureOrTodayOnly(ErrorMessage = "Start date must be today or in the future")]
    public DateOnly StartDate { get; set; }
    [Required(ErrorMessage = "End date is required")]
    [FutureOrTodayOnly(ErrorMessage = "End date must be today or in the future")]
    public DateOnly EndDate { get; set; }
}

public class UpdateAcademicTermRequestModel : CreateAcademicTermRequestModel { }