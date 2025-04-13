using System.ComponentModel.DataAnnotations;

namespace Shares.Attributes;

public class PastDateOnlyAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is DateOnly date)
        {
            return date <= DateOnly.FromDateTime(DateTime.Today);
        }

        return false;
    }
}

public class FutureOrTodayOnlyAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is DateOnly date)
        {
            return date >= DateOnly.FromDateTime(DateTime.Today);
        }

        return false;
    }
}