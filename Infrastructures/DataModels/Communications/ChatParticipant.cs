namespace Infrastructures.DataModels.Communications;

public class ChatParticipant : BaseDataModel
{
    public string ChatRoomId { get; set; } = null!;
    public string UserId { get; set; } = null!;

    public bool IsAdmin { get; set; }
    public DateTime JoinedAt { get; set; } = DateTime.Now;
}