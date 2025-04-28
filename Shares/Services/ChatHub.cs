using Microsoft.AspNetCore.SignalR;

namespace Shares.Services;

public class ChatHub : Hub
{
    public static readonly HashSet<string> OnlineUserIds = [];
    public static readonly Dictionary<string, DateTime> UserLastSeen = new();

    public override async Task OnConnectedAsync()
    {
        var userId = Context.User?.FindFirst("sub")?.Value;

        if (!string.IsNullOrEmpty(userId))
        {
            OnlineUserIds.Add(userId);
            UserLastSeen.Remove(userId);
            await Clients.All.SendAsync("UserStatusChanged", userId, true);
        }

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var userId = Context.User?.FindFirst("sub")?.Value;

        if (!string.IsNullOrEmpty(userId))
        {
            OnlineUserIds.Remove(userId);
            UserLastSeen[userId] = DateTime.UtcNow;
            await Clients.All.SendAsync("UserStatusChanged", userId, false);
        }

        await base.OnDisconnectedAsync(exception);
    }

    public async Task JoinRoom(string chatRoomId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, chatRoomId);
    }

    public async Task LeaveRoom(string chatRoomId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatRoomId);
    }

}