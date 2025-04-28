using MassTransit;
using Microsoft.AspNetCore.SignalR;
using Shares.Models.Communications;

namespace Shares.Services;

public class ChatMessageConsumer(IHubContext<ChatHub> hubContext) : IConsumer<ChatMessageEvent>
{
    public async Task Consume(ConsumeContext<ChatMessageEvent> context)
    {
        var message = context.Message;
        await hubContext.Clients.Group(message.ChatRoomId)
            .SendAsync("ReceiveMessage", message.SenderId, message.Content);
    }
}