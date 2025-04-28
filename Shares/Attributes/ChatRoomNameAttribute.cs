using System.ComponentModel.DataAnnotations;
using Shares.Models.Communications;

namespace Shares.Attributes;

public class ChatRoomNameAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var requestModel = (CreateChatRoomRequestModel)validationContext.ObjectInstance;

        if (!requestModel.IsGroup) return ValidationResult.Success;
        return string.IsNullOrWhiteSpace(requestModel.Name)
            ? new ValidationResult("Group chat must have a name.")
            : ValidationResult.Success;
    }
}