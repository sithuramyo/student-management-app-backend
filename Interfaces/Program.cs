using System.Text;
using Interfaces.Builders;
using Interfaces.Globals;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using Infrastructures.Builders;
using Shares.Services;


var builder = WebApplication.CreateBuilder(args);


var state = builder.Configuration.GetSection("State").Value;
var url = "http://localhost:5000";
if ((int)State.Deployment == Convert.ToInt32(state))
{
    url = "http://0.0.0.0:5000";
}

builder.WebHost.UseUrls(url);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];
var jwtSecret = builder.Configuration["Jwt:Secret"];

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            RequireExpirationTime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = key
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policyBuilder =>
    {
        policyBuilder.WithOrigins(
                "http://localhost:3000"
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.InjectServices();
builder.Services.AddControllers();
builder.Services.AddDatabaseInjection(builder.Configuration);
builder.Services.AddRabbitMqInjection(builder.Configuration);
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
            StatusCode = StatusCodes.Status422UnprocessableEntity,
            Errors = errors
        };
        return new UnprocessableEntityObjectResult(apiResponse);
    };
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowSpecificOrigins");
app.UseAuthentication();
app.UseAuthorization();

app.UseExceptionHandler(_ => { });
app.MapGet("/", () => "Student Management API");
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.MapControllers();
app.MapHub<ChatHub>("/chatHub");
app.Run();