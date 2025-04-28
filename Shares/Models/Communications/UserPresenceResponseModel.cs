namespace Shares.Models.Communications;

public class UserPresenceResponseModel
{
    public string UserId { get; set; } = null!;
    public bool IsOnline { get; set; }
    public DateTime? LastSeen { get; set; }
}