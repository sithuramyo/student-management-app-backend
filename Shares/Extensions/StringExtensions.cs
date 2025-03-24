namespace Shares.Extensions;

public static class StringExtensions
{
    public static string GetCode(this string str, int count, string digit)
    {
        var formattedNumber = (count + 1).ToString(digit);
        return $"{str}{formattedNumber}";
    }
}