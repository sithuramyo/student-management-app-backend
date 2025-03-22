using System.Net;
using System.Text.Json.Serialization;

namespace Shares.Models.ApiModels;

public class ApiResponse<T>
{
    public bool IsSuccess { get; set; }

    public string Message { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public T? Data { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int StatusCode { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public List<string> Errors { get; set; }

    public static ApiResponse<T> Success(T data, string message = "Success")
    {
        return new ApiResponse<T> { IsSuccess = true, Message = message, Data = data };
    }

    public static ApiResponse<T> Created(string message)
    {
        return new ApiResponse<T>
        { IsSuccess = true, Message = $"{message} is created", StatusCode = (int)HttpStatusCode.OK };
    }

    public static ApiResponse<T> Updated(string message)
    {
        return new ApiResponse<T>
        { IsSuccess = true, Message = $"{message} is updated", StatusCode = (int)HttpStatusCode.OK };
    }

    public static ApiResponse<T> Deleted(string message)
    {
        return new ApiResponse<T>
        { IsSuccess = true, Message = $"{message} is deleted", StatusCode = (int)HttpStatusCode.OK };
    }

    public static ApiResponse<T> BadRequest(string message)
    {
        return new ApiResponse<T>
        { IsSuccess = false, Message = message, StatusCode = (int)HttpStatusCode.BadRequest };
    }

    public static ApiResponse<T> NotFound(string message)
    {
        return new ApiResponse<T> { IsSuccess = false, Message = message, StatusCode = (int)HttpStatusCode.NotFound };
    }
}