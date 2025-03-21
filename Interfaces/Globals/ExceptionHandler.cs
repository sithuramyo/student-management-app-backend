using Microsoft.AspNetCore.Diagnostics;

namespace Interfaces.Globals;

public class ExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        ApiResponse<ErrorResponse> errorResponseModel = new()
        {
            StatusCode = StatusCodes.Status500InternalServerError,
            Message = "Something went wrong"
        };
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(errorResponseModel, cancellationToken);
        return true;
    }
}