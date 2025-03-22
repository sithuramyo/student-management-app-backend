namespace Infrastructures.DataModels.Communications;

public class ChatParticipant : BaseDataModel
{
    public string ChatRoomId { get; set; }
    public string UserId { get; set; }

    public bool IsAdmin { get; set; } = false;
    public DateTime JoinedAt { get; set; } = DateTime.Now;
}