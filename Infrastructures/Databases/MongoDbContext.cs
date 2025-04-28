using Infrastructures.DataModels.Communications;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infrastructures.Databases;

public class MongoDbContext : IMongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
        _database = client.GetDatabase(configuration["MongoDatabaseName"]);
    }

    public IMongoCollection<ChatMessage> ChatMessages =>
        _database.GetCollection<ChatMessage>("ChatMessages");
}