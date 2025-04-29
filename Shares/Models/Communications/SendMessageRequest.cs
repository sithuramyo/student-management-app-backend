namespace Shares.Models.Communications;

public class SendMessageRequest
{
    public string Content { get; set; } = null!;
}

public class SendMessageResponse
{
    public string Id { get; set; } = null!;
}