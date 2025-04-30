namespace Shares.Models.Communications;

public class UsersResponseModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Profile { get; set; }
    public string? ChatRoomId { get; set; }
    public bool IsOnline { get; set; }
    public DateTime? LastSeen { get; set; }
}