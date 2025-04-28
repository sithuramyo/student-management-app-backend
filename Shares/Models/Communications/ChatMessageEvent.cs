namespace Shares.Models.Communications;

public class ChatMessageEvent
{
    public string ChatRoomId { get; set; } = null!;
    public string SenderId { get; set; } = null!;
    public string Content { get; set; } = null!;
}