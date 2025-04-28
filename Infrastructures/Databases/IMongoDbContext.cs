using Infrastructures.DataModels.Communications;
using MongoDB.Driver;

namespace Infrastructures.Databases;

public interface IMongoDbContext
{
    IMongoCollection<ChatMessage> ChatMessages { get; }
}