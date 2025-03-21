namespace Shares.Models.ApiModels;

public class ErrorResponse
{
    public int StatusCode { get; set; }
    public string ErrorMessage { get; set; } = null!;
}