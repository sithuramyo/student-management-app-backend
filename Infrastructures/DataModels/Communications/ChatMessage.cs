namespace Infrastructures.DataModels.Communications;

public class ChatMessage : BaseDataModel
{
    public string ChatRoomId { get; set; }
    public string SenderId { get; set; }

    public string Content { get; set; }
    public DateTime SentAt { get; set; } = DateTime.Now;
    public bool IsSeen { get; set; } = false;
}