namespace Shares.Models.Communications;

public class ChatMessageResponseModel
{
    public string Id { get; set; } = null!;
    public string SenderId { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime SentAt { get; set; }

    public bool IsOwnMessage { get; set; }
    public List<string>? SeenBy { get; set; }
}