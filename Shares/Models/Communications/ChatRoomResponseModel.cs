namespace Shares.Models.Communications;

public class ChatRoomResponseModel
{
    public string Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsGroup { get; set; }
    public DateTime CreatedAt { get; set; }
}