using Shares.Attributes;

namespace Shares.Models.Communications;

public class CreateChatRoomRequestModel
{
    [ChatRoomName]
    public string? Name { get; set; }
    public bool IsGroup { get; set; }
    public List<string> ParticipantIds { get; set; } = [];
}


public class CreateChatRoomResponseModel
{
    public string Id { get; set; } = null!;
}