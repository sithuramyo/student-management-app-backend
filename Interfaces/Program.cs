using Interfaces.Builders;
using Interfaces.Globals;

var builder = WebApplication.CreateBuilder(args);


var state = builder.Configuration.GetSection("State").Value;
var url = "http://localhost:5000";
if ((int)State.DEVPLOYMENT == Convert.ToInt32(state))
{
    url = "http://0.0.0.0:5000";
}

builder.WebHost.UseUrls(url);
builder.Services.InjectServices();
builder.Services.AddControllers();
builder.Services.AddDatabaseInjection(builder.Configuration);
builder.Services.AddExceptionHandler<ExceptionHandler>();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();

        var apiResponse = new ApiResponse<List<string>>
        {
            IsSuccess = false,
            Message = "Validation failed",
            StatusCode = StatusCodes.Status400BadRequest,
            Errors = errors
        };
        return new BadRequestObjectResult(apiResponse);
    };
});

var app = builder.Build();
app.UseExceptionHandler(_ => { });
app.MapGet("/", () => "Student Management API");
app.MapControllers();
app.Run();