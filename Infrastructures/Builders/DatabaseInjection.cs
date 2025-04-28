using Infrastructures.Databases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructures.Builders;

public static class DatabaseInjection
{
    public static void AddDatabaseInjection(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Postgres");
        services.AddHealthChecks()
            .AddNpgSql(connectionString)
            .AddMongoDb(configuration.GetConnectionString("MongoDb"));
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString)
        );
        services.AddSingleton<IMongoDbContext, MongoDbContext>();
    }
}