namespace Infrastructures.DataModels.Communications;

public class ChatMessage : BaseDataModel
{
    public string ChatRoomId { get; set; } = null!;
    public string SenderId { get; set; } = null!;

    public string Content { get; set; } = null!;
    public DateTime SentAt { get; set; } = DateTime.Now;
    public bool IsSeen { get; set; }
}