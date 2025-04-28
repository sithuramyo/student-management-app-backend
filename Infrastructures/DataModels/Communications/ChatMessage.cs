using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructures.DataModels.Communications;

[BsonIgnoreExtraElements]
public class ChatMessage
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    public string ChatRoomId { get; set; } = null!;
    public string SenderId { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime SentAt { get; set; } = DateTime.Now;
    public List<string> SeenByUserIds { get; set; } = [];
}