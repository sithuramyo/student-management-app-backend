using MassTransit;
using Microsoft.AspNetCore.SignalR;
using Shares.Models.Communications;

namespace Shares.Services;

public class ChatMessageConsumer(IHubContext<ChatHub> hubContext) : IConsumer<ChatMessageEvent>
{
    public async Task Consume(ConsumeContext<ChatMessageEvent> context)
    {
        var message = context.Message;

        if (string.IsNullOrWhiteSpace(message.ChatRoomId))
        {
            Console.WriteLine(
                $"[Warning] Received ChatMessageEvent with null or empty ChatRoomId. SenderId: {message.SenderId}");
            return;
        }

        await hubContext.Clients.Group(message.ChatRoomId)
            .SendAsync("ReceiveMessage", new
            {
                message.SenderId,
                message.Content,
                message.ChatRoomId,
            });
    }
}