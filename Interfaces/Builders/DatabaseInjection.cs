namespace Interfaces.Builders;

public static class DatabaseInjection
{
    public static void AddDatabaseInjection(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddHealthChecks()
            .AddNpgSql(connectionString);
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString)
        );
    }
}