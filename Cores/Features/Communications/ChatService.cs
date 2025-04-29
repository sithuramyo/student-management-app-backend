using Infrastructures.DataModels.Communications;
using MassTransit;
using MongoDB.Driver;
using Shares.Models.Communications;
using Shares.Services;

namespace Cores.Features.Communications;

public class ChatService(AppDbContext context, IMongoDbContext mongoDbContext, IPublishEndpoint publishEndpoint)
    : IChatService
{

    public async Task<ApiResponse<List<UsersResponseModel>>> GetChatUsersAsync(string search, string currentUserId)
    {
        var query = context.SystemUsers.AsNoTracking();

        if (!string.IsNullOrEmpty(search))
        {
            search = search.ToLower();
            query = query.Where(d =>
                EF.Functions.ILike(d.Name, $"%{search}%") ||
                EF.Functions.ILike(d.Email, $"%{search}%"));
        }

        var userChatParticipants = await context.ChatParticipants
            .Where(cp => cp.UserId != currentUserId &&
                         context.ChatParticipants
                             .Where(inner => inner.UserId == currentUserId)
                             .Select(inner => inner.ChatRoomId)
                             .Contains(cp.ChatRoomId))
            .ToListAsync();

        var userIdToChatRoomId = userChatParticipants
            .GroupBy(cp => cp.UserId)
            .ToDictionary(g => g.Key, g => g.First().ChatRoomId);

        var users = await query
            .Where(x => x.Role == SystemUserRole.SuperAdmin.ToString())
            .ToListAsync();

        var result = users.Select(user => new UsersResponseModel
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Profile = user.Profile ?? "N/A",
            ChatRoomId = userIdToChatRoomId.GetValueOrDefault(user.Id)
        }).ToList();

        return ApiResponse<List<UsersResponseModel>>.Success(result);
    }

    public async Task<ApiResponse<List<ChatRoomResponseModel>>> GetChatRooms(string userId)
    {
        var chatroomIds = await context.ChatParticipants.Where(x => x.UserId == userId).Select(x => x.ChatRoomId)
            .ToListAsync();
        var response = await context.ChatRooms.Where(x => chatroomIds.Contains(x.Id))
            .Select(x => new ChatRoomResponseModel
            {
                Id = x.Id,
                Name = x.Name,
                IsGroup = x.IsGroup,
                CreatedAt = x.CreatedAt,
            }).ToListAsync();
        return ApiResponse<List<ChatRoomResponseModel>>.Success(response);
    }

    public async Task<ApiResponse<List<ChatMessageResponseModel>>> GetChatMessages(string userId, string roomId,
        int page, int pageSize)
    {
        var skip = (page - 1) * pageSize;

        var messages = await mongoDbContext.ChatMessages
            .Find(x => x.ChatRoomId == roomId)
            .SortByDescending(x => x.SentAt)
            .Skip(skip)
            .Limit(pageSize)
            .ToListAsync();

        var response = messages.Select(x => new ChatMessageResponseModel
        {
            Id = x.Id,
            SenderId = x.SenderId,
            Content = x.Content,
            SentAt = x.SentAt,
            IsOwnMessage = x.SenderId == userId,
            SeenBy = x.SeenByUserIds
        }).ToList();

        return ApiResponse<List<ChatMessageResponseModel>>.Success(response);
    }

    public async Task<ApiResponse<CreateChatRoomResponseModel>> CreateChatRoom(CreateChatRoomRequestModel request,
        string creatorUserId)
    {
        CreateChatRoomResponseModel response = new();

        ChatRoom data = new()
        {
            Name = request.Name,
            IsGroup = request.IsGroup,
        };

        await context.ChatRooms.AddAsync(data);
        await context.SaveChangesAsync();

        var participantUserIds = new HashSet<string>(request.ParticipantIds) { creatorUserId };
        var participants = participantUserIds.Select(userId => new ChatParticipant
        {
            ChatRoomId = data.Id,
            UserId = userId,
            IsAdmin = userId == creatorUserId
        }).ToList();

        await context.ChatParticipants.AddRangeAsync(participants);
        await context.SaveChangesAsync();
        response.Id = data.Id;
        return ApiResponse<CreateChatRoomResponseModel>.Success(response);
    }

    public async Task<ApiResponse<SendMessageResponse>> SendMessage(string senderId,
        SendMessageRequest request)
    {
        SendMessageResponse response = new();
        var chatMessage = new ChatMessage
        {
            ChatRoomId = request.RoomId,
            SenderId = senderId,
            Content = request.Content,
            SentAt = DateTime.UtcNow,
            SeenByUserIds = [senderId]
        };

        await mongoDbContext.ChatMessages.InsertOneAsync(chatMessage);

        await publishEndpoint.Publish(new ChatMessageEvent
        {
            ChatRoomId = request.RoomId,
            SenderId = senderId,
            Content = request.Content
        });
        response.Id = chatMessage.Id;
        return ApiResponse<SendMessageResponse>.Success(response);
    }

    public Task<ApiResponse<UserPresenceResponseModel>> GetUserPresence(string userId)
    {
        var isOnline = ChatHub.OnlineUserIds.Contains(userId);
        var lastSeen = ChatHub.UserLastSeen.TryGetValue(userId, out var value) ? value : (DateTime?)null;

        var response = new UserPresenceResponseModel
        {
            UserId = userId,
            IsOnline = isOnline,
            LastSeen = isOnline ? null : lastSeen
        };

        return Task.FromResult(ApiResponse<UserPresenceResponseModel>.Success(response));
    }


    public async Task<ApiResponse<List<UserStatusResponseModel>>> GetParticipantsStatus(string roomId, string currentUserId)
    {
        var participantUserIds = await context.ChatParticipants
            .Where(x => x.ChatRoomId == roomId && x.UserId != currentUserId)
            .Select(x => x.UserId)
            .ToListAsync();

        var response = participantUserIds.Select(userId => new UserStatusResponseModel
        {
            UserId = userId,
            IsOnline = ChatHub.OnlineUserIds.Contains(userId),
            LastSeen = ChatHub.UserLastSeen.TryGetValue(userId, out var value) ? value : null
        }).ToList();

        return ApiResponse<List<UserStatusResponseModel>>.Success(response);
    }

}